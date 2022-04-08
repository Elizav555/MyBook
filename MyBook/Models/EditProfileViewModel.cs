using System.ComponentModel.DataAnnotations;

namespace MyBook.Models
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано имя"), DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия"), DataType(DataType.Text)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }

    public class EditPasswordViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Введите старый пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Введите новый пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string NewPassword { get; set; }
    }
}
