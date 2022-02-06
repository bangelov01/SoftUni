namespace CarShop.Services
{
    using CarShop.Models.Cars;
    using CarShop.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using static Data.Common.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateCarAddition(AddCarFormModel model)
        {
            var errors = new List<string>();

            if (model.Model.Length < CAR_MODEL_MIN_LENGTH || model.Model.Length > CAR_MODEL_MAX_LENGTH)
            {
                errors.Add($"Car Model must be between {CAR_MODEL_MIN_LENGTH} and {CAR_MODEL_MAX_LENGTH}!");
            }

            if (!Uri.IsWellFormedUriString(model.Image, UriKind.Absolute))
            {
                errors.Add($"Image {model.Image} is not a valid URL!");
            }

            if (!Regex.IsMatch(model.PlateNumber, PLATENUMBER_REGEX))
            {
                errors.Add($"Platenumber {model.PlateNumber} is not in the correct format! The correct format is: AA0000AA");
            }

            return errors;
        }

        public ICollection<string> ValidateUserRegistration(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.UserName.Length < USERNAME_MIN_LENGTH
                || model.UserName.Length > USERNAME_MAX_LENGTH)
            {
                errors.Add($"Username must be between {USERNAME_MIN_LENGTH} and {USERNAME_MAX_LENGTH}!");
            }

            if (model.Password.Length < PASSWORD_MIN_LENGTH
                || model.Password.Length > PASSWORD_MAX_LENGTH)
            {
                errors.Add($"Password length must be between {PASSWORD_MIN_LENGTH} and {PASSWORD_MAX_LENGTH}!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and Confirm Password do not match!");
            }

            if (model.UserType != USER_CLIENT && model.UserType != USER_MECHANIC)
            {
                errors.Add($"User must be a {USER_CLIENT} or {USER_MECHANIC}!");
            }

            return errors;
        }
    }
}
