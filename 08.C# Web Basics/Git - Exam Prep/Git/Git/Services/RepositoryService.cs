namespace Git.Services
{
    using Git.Data.Models;
    using static Data.Constatnts.DataConstants;
    using System;
    using Git.Data;
    using System.Collections.Generic;
    using Git.ViewModels.Repositories;
    using System.Linq;
    using System.Globalization;

    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext dbContext;
        public RepositoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateRepository(string name,
            string type,
            string ownerId)
        {
            var repo = new Repository
            {
                Name = name,
                OwnerId = ownerId,
                IsPublic = type == REPOSITORY_PUBLIC
            };

            dbContext.Repositories.Add(repo);
            dbContext.SaveChanges();
        }

        public List<RepositoryListingViewModel> GetRepositories()
        {
            return dbContext
                .Repositories
                .Where(r => r.IsPublic == true)
                .Select(r => new RepositoryListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToString("r", CultureInfo.InvariantCulture),
                    Commits = r.Commits.Count()
                })
                .ToList();
        }
    }
}
