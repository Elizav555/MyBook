﻿using System.ComponentModel.DataAnnotations;

namespace MyBook.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Введите email") ]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указано имя"), DataType(DataType.Text)][Display(Name = "FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия"), DataType(DataType.Text)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateOnly BirthDate { get; set; }
    }
}
