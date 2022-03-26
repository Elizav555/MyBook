using System.ComponentModel.DataAnnotations;

namespace MyBook.Models
{
    public class RegistrationModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
    }
}
