using System.ComponentModel.DataAnnotations;

namespace MyBook.Models
{
    public class SignInModel
    {
        const string email = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        [Required(ErrorMessage = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(email, ErrorMessage = "Email должен быть действителен")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.А также минимум одну цифру", MinimumLength = 6)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
