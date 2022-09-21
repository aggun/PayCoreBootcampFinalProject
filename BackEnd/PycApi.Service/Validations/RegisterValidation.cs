using FluentValidation;
using PycApi.Dto.Dto;
using System.Linq;

namespace PycApi.Service.Validations
{
    public class RegisterValidation : AbstractValidator<AccountDto>
    {

        public RegisterValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Adresi girmek zorunludur.")
              .EmailAddress().WithMessage("Geçerli bir Email adresi girin.");

            RuleFor(x => x.Password).NotEmpty()
           .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır.")
           .MaximumLength(20).WithMessage("Şifre  en fazla 20 karakter olmalıdır.")
           .Matches("[A-Z]").WithMessage("En az bir veya daha fazla büyük harf içermelidir.")
           .Matches("[a-z]").WithMessage("En az bir veya daha fazla küçük harf içermelidir.")
           .Matches(@"\d").WithMessage("\"En az bir veya daha fazla küçük sayı içermelidir.")
           .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("En az bir veya daha fazla özel karakter içermelidir")
           .Matches("^[^£# “”]*$").WithMessage("Boşluk veya geçersiz karakter girmeyin.");
        }
    }
}
