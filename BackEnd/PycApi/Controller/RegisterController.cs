using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PycApi.Data.Model;
using PycApi.Dto.Dto;
using PycApi.RabbitMqServices;
using PycApi.Service;
using PycApi.Service.Utilities.Hashing;
using PycApi.Service.Validations;
using Serilog;
using System;


namespace PycApi.Controller
{
    [Route("api/nhb/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly RabbitMQPublisher rabbitMQPublisher;

        public RegisterController(IAccountService accountService, RabbitMQPublisher rabbitMQPublisher)
        {
            this.accountService = accountService;
            this.rabbitMQPublisher = rabbitMQPublisher;

        }

        [HttpPost]
        public IActionResult Register([FromBody] AccountDto accountDto)
        {
            RegisterValidation validationRules = new RegisterValidation();

            ValidationResult result = validationRules.Validate(accountDto);
            if (result.IsValid)
            {
                try
                {
                    byte[] passwordHash, passwordSalt;
                    HashingHelper.CreatePasswordHash(accountDto.Password, out passwordHash, out passwordSalt);
                    var account = new Account();

                    account.Id = Guid.NewGuid().ToString();
                    account.Name = accountDto.Name;
                    account.LastActivity = DateTime.UtcNow;
                    account.Email = accountDto.Email;
                    account.PasswordHash = passwordHash;
                    account.PasswordSalt = passwordSalt;

                    accountService.Insert(account);
                    rabbitMQPublisher.Publish(new SendEmailEvent() { EmailAdress = account.Email });

                    return Ok(account);
                }
                catch (Exception ex)
                {
                    Log.Error("Register :", ex.Message);
                    return BadRequest();
                }
            }
            else
            {
                foreach (var item in result.Errors)
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                return BadRequest(ModelState);
            }
        }
    }
}
