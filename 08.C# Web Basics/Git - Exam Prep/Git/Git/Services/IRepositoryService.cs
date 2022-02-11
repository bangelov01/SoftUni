
namespace Git.Services
{
    using Git.ViewModels.Repositories;
    using System;
    using System.Collections.Generic;

    public interface IRepositoryService
    {
        void CreateRepository(string name,
            string type,
            string ownerId);

        List<RepositoryListingViewModel> GetRepositories();
    }
}
