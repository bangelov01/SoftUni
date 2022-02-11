namespace Git.Services
{
    using Git.ViewModels.Commits;
    using Git.ViewModels.Repositories;
    using Git.ViewModels.Users;
    using System.Collections.Generic;

    public interface IValidatorService
    {
        ICollection<string> ValidateUserRegistration(RegisterUserFormModel model);

        bool ValidateRepositoryCreation(RepositoryFormModel model);

        bool ValidateCommitCreation(CommitFormModel model);
    }
}
