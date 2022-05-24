using System.ComponentModel.DataAnnotations;

namespace MyBook.Models
{
    public class RegistrationModel
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

        [Required(ErrorMessage = "Не указано имя"), DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия"), DataType(DataType.Text)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Не указана дата рождения")]
        [DataType(DataType.Date, ErrorMessage = "Введите корректную дату рождения")]
        public DateTime? BirthDate { get; set; }
    }
}
