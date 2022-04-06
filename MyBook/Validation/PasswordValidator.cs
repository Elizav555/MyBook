using Microsoft.AspNetCore.Identity;
using MyBook.Entities;
using System.Text.RegularExpressions;

namespace MyBook.Validation
{
    public class PasswordValidator : IPasswordValidator<User>
    {
        public int RequiredLength { get; set; } // минимальная длина

        public PasswordValidator(int length)
        {
            RequiredLength = length;
        }

        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (String.IsNullOrEmpty(password) || password.Length < RequiredLength)
            {
                errors.Add(new IdentityError
                {
                    Description = $"Минимальная длина пароля равна {RequiredLength}"
                });
            }
            if (string.Equals(user.UserName, password, StringComparison.OrdinalIgnoreCase))
            {
                errors.Add(new IdentityError
                {
                    Code = "UsernameAsPassword",
                    Description = "You cannot use your username as your password"
                });
            }
            
            string pattern = @"^(?=.*\d)(?=.*[a - z])(?=.*[A - Z])(?!.*\s).*$";

            if (!Regex.IsMatch(password, pattern))
            {
                errors.Add(new IdentityError
                {
                    Description = "Пароль должен состоять из строчных и прописных латинских букв, цифр"
                });
            }
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
