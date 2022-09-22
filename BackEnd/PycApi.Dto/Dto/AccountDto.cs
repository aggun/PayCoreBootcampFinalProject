using System;
using System.ComponentModel.DataAnnotations;

namespace PycApi.Dto.Dto
{
    public class AccountDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
