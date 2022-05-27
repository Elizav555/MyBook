using MyBook.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyBook.Models.Admin
{
    public class EditCenterViewModel
    {
        const string text = @"^([А-Я]|[а-яё]|[A-z]|[A-z]|\s|\d|[.,!?:;\-,\/,@])*$";
        const string phone = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
        const string lat = @"^-?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))$";
        const string lon = @"^-?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))$";
        public int? BookCenterId { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [MaxLength(50, ErrorMessage = "Длина названия не должна превышать 50 символов"), MinLength(5, ErrorMessage = "Длина названия не должна быть меньше 5 символов")]
        [RegularExpression(text, ErrorMessage = "Введите корректное название", MatchTimeoutInMilliseconds = 10)]
        [DataType(DataType.Text)]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Введите адрес")]
        [MaxLength(50, ErrorMessage = "Длина адреса не должна превышать 50 символов"), MinLength(5, ErrorMessage = "Длина адреса не должна быть меньше 5 символов")]
        [RegularExpression(text, ErrorMessage = "Введите корректный адрес", MatchTimeoutInMilliseconds = 10)]
        [DataType(DataType.Text)]
        public string Address { get; set; } = null!;
        [Required(ErrorMessage = "Введите номер")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(phone, ErrorMessage = "Введите корректный номер")]
        public string Phone { get; set; } = null!;
        [Required(ErrorMessage = "Введите описание")]
        [DataType(DataType.MultilineText)]
        [RegularExpression(text, ErrorMessage = "Пожалуйста, используйте буквы,цифры и знаки препинания")]
        [MaxLength(500, ErrorMessage = "Длина описания не должна превышать 500 символов"), MinLength(5, ErrorMessage = "Длина описания не должна быть меньше 10 символов")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Введите широту")]
        [RegularExpression(lat, ErrorMessage = "Пожалуйста, введите корректную широту")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Введите долготу")]
        [RegularExpression(lon, ErrorMessage = "Пожалуйста, введите корректную долготу")]
        public string Longitude { get; set; }
    }
}
