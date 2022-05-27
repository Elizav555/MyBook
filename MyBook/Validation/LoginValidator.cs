using Microsoft.AspNetCore.Identity;
using MyBook.Entities;
using System.Text.RegularExpressions;
using MyBook.Core.Validation;

namespace MyBook.Validation
{
    public class UserValidator : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (!Regex.IsMatch(user.Email, Validator.Email))
            {
                errors.Add(new IdentityError
                {
                    Description = "Email должен быть действителен"
                });
            }
            if (!Regex.IsMatch(user.FirstName,Validator.LettersValidationString)|| !Regex.IsMatch(user.LastName, Validator.LettersValidationString))
            {
                errors.Add(new IdentityError
                {
                    Description = "Имя и фамилия должны состоять только из букв и начинаться с большой буквы"
                });
            }
            var date = DateTime.Parse(user.BirthDate);
            if (date.CompareTo(DateTime.Now.Date)>0 || date.CompareTo(Validator.MinDate) < 0) 
            {
                errors.Add(new IdentityError
                {
                    Description = "Введите корректную дату рождения"
                });
            }
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
