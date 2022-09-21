using System.ComponentModel.DataAnnotations;

namespace PycApi.Base
{
    public class TokenRequest
    {
        [Required(ErrorMessage ="Email zorunludur.")]
        [MaxLength(125)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Şifre zorunludur.")]

        public string Password { get; set; }
    }
}
