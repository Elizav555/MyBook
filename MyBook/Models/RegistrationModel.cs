using System.ComponentModel.DataAnnotations;

namespace MyBook.Models
{
    public class RegistrationModel
    {
        //как то поменять текст и место отображения ошибки пароля от Identity
        //не отображаются ошибки для проверки регулярками имени и фамилии
        // изменить формат ввода даты рождения
        const string letters = @"^([А-Я][а-яё]{2,50}|[A-Z][a-z]{2,50})$";
        const string email = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
        [Required(ErrorMessage = "Введите email") ]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(email, ErrorMessage = "Email должен быть действителен")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.А также минимум одну цифру", MinimumLength = 6)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано имя"), DataType(DataType.Text)]
        [RegularExpression(letters, ErrorMessage = "Имя и фамилия должны состоять только из букв и начинаться с большой буквы")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия"), DataType(DataType.Text)]
        [RegularExpression(letters, ErrorMessage = "Имя и фамилия должны состоять только из букв и начинаться с большой буквы")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly BirthDate { get; set; }
    }
}
