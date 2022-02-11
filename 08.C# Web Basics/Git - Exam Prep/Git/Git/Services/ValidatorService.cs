namespace Git.Services
{
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;
    using Git.ViewModels.Users;
    using System.Collections.Generic;
    using static Data.Constatnts.DataConstants;

    public class ValidatorService : IValidatorService
    {
        public bool ValidateCommitCreation(CommitFormModel model)
        {
            if (model.Description.Length < COMMIT_DESCRIPTION_MIN_LENGTH)
            {
                return false;
            }

            return true;
        }

        public bool ValidateRepositoryCreation(RepositoryFormModel model)
        {
            if (model.Name.Length < REPOSITORY_NAME_MIN_LENGTH
                || model.Name.Length > REPOSITORY_NAME_MAX_LENGTH)
            {
                return false;
            }

            return true;
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

            return errors;
        }
    }
}
