namespace SMS.Services
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    using SMS.Contracts;
    using SMS.Models.Products;
    using SMS.Models.Users;
    using SMS.Data;

    using static Data.Constants.DataConstants;

    public class ValidatorService : IValidatorService
    {
        private readonly SMSDbContext dbContext;

        public ValidatorService(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<string> ValidateProductCreation(CreateProductFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < ProductNameMinLength
                || model.Name.Length > ProductNameMaxLength)
            {
                errors.Add($"Name must be between {ProductNameMinLength} and {ProductNameMaxLength} characters long!");
            }

            if (model.Price < decimal.Parse(PriceMinValue)
                || model.Price > decimal.Parse(PriceMaxValue))
            {
                errors.Add($"Price must be between {PriceMinValue} and {PriceMaxValue}!");
            }

            return errors;
        }

        public ICollection<string> ValidateUserRegistration(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UsernameMinLength
                || model.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username must be between {UsernameMinLength} and {UsernameMaxLength} characters long!");
            }

            if (model.Password.Length < PasswordMinLength
                || model.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password length must be between {PasswordMinLength} and {PasswordMaxLength}!");
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                errors.Add("Email cannot be empty!");
            }

            if (!Regex.IsMatch(model.Email, EmailValidationRegex))
            {
                errors.Add("Email is not valid!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and Confirm Password do not match!");
            }

            if (errors.Any())
            {
                return errors;
            }

            if (!this.IsUsernameAvailable(model.Username))
            {
                errors.Add("Username already exists!");
                return errors;
            }

            if (!this.IsEmailAvailable(model.Email))
            {
                errors.Add("Email already exists!");
                return errors;
            }

            if (!this.IsEmailAvailable(model.Email)
                && !this.IsUsernameAvailable(model.Username))
            {
                errors.Add("Email and Password already exist!");
                return errors;
            }

            return errors;
        }

        private bool IsEmailAvailable(string email)
        {
            if (this.dbContext
            .Users
            .Any(u => u.Email == email))
            {
                return false;
            }

            return true;
        }

        private bool IsUsernameAvailable(string username)
        {
            if (this.dbContext
            .Users
            .Any(u => u.Username == username))
            {
                return false;
            }

            return true;
        }
    }
}
