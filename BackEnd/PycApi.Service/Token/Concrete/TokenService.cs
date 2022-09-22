using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NHibernate;
using PycApi.Base;
using PycApi.Data;
using PycApi.Data.Model;
using PycApi.Dto;
using PycApi.Service.Utilities.Hashing;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PycApi.Service
{
    public class TokenService : ITokenService
    {

        protected readonly ISession session;
        protected readonly IHibernateRepository<Account> hibernateRepository;
        private readonly JwtConfig jwtConfig;

        public TokenService(ISession session,  IOptionsMonitor<JwtConfig> jwtConfig)
        {
            this.session = session;
            this.jwtConfig = jwtConfig.CurrentValue;
            hibernateRepository = new HibernateRepository<Account>(session);
        }

        public BaseResponse<TokenResponse> GenerateToken(TokenRequest tokenRequest)
        {
            try
            {
                if (tokenRequest is null)
                {
                    return new BaseResponse<TokenResponse>("Email ve şifrenizi giriniz..");
                }

                var account = hibernateRepository.Where(x => x.Email.Equals(tokenRequest.Email)).FirstOrDefault();
                if (account is null)
                {
                    return new BaseResponse<TokenResponse>("Kullanıcı adı ve şifrenizi gözden geçirin.");
                }
                if (!HashingHelper.VerifyPasswordHash(tokenRequest.Password, account.PasswordHash, account.PasswordSalt))
                {
                    return new BaseResponse<TokenResponse>("Kullanıcı adı ve şifrenizi gözden geçirin.");
                }

                DateTime now = DateTime.UtcNow;
                string token = GetToken(account, now);

                try
                {
                    account.LastActivity = now;

                    hibernateRepository.BeginTransaction();
                    hibernateRepository.Update(account);
                    hibernateRepository.Commit();
                    hibernateRepository.CloseTransaction();
                }
                catch (Exception ex)
                {
                    Log.Error("GenerateToken Update Account LastActivity:", ex);
                    hibernateRepository.Rollback();
                    hibernateRepository.CloseTransaction();
                }

                TokenResponse tokenResponse = new TokenResponse
                {
                    AccessToken = token,
                    ExpireTime = now.AddMinutes(jwtConfig.AccessTokenExpiration),
                    Email = account.Email,
                    Name = account.Name,
                    AccountId = account.Id,
                    SessionTimeInSecond = jwtConfig.AccessTokenExpiration * 60
                };

                return new BaseResponse<TokenResponse>(tokenResponse);
            }
            catch (Exception ex)
            {
                Log.Error("GenerateToken :", ex);
                return new BaseResponse<TokenResponse>("GenerateToken Error");
            }
        }


        private string GetToken(Account account, DateTime date)
        {
            Claim[] claims = GetClaims(account);
            byte[] secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);

            var jwtToken = new JwtSecurityToken(
                jwtConfig.Issuer,
                shouldAddAudienceClaim ? jwtConfig.Audience : string.Empty,
                claims,
                expires: date.AddMinutes(jwtConfig.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }

        private Claim[] GetClaims(Account account)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                new Claim(ClaimTypes.Email, account.Email),
                 new Claim(ClaimTypes.Name,account.Email),
                new Claim("AccountId", account.Id.ToString())
               
            };

            return claims;
        }
    }
}
