using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MyBook.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [MaxLength(64)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [MaxLength(18)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
