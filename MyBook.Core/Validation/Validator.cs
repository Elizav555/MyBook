namespace MyBook.Core.Validation;

public static class Validator
{
    public static readonly DateTime MinDate = DateTime.Parse("06.04.1922");
    public const string Letters = @"^([А-Я][а-яё]{2,50}|[A-Z][a-z]{2,50})$";
    public const string Email = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
}