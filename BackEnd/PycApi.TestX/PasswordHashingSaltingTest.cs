using System.Text;
using Xunit;

namespace PycApi.TestX
{
    public class PasswordHashingSaltingTest
    {
        [Fact]
        public void CreatePasswordHash()
        {
            string password = "password";
            var hmac = new System.Security.Cryptography.HMACSHA512();

            byte[] passwordSalt = hmac.Key;
            byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            var hmac1 = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedPasswordHash = hmac1.ComputeHash(Encoding.UTF8.GetBytes(password));

            Assert.Equal(passwordHash, computedPasswordHash);
        }
    }
}

