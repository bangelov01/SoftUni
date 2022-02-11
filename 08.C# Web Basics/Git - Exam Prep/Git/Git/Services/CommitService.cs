

namespace Git.Services
{
    using Git.Data;
    using Git.Data.Models;
    using Git.ViewModels.Commits;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class CommitService : ICommitService
    {
        private readonly ApplicationDbContext dbContext;
        public CommitService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateCommit(string description,
            string ownerId,
            string repoId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatorId = ownerId,
                RepositoryId = repoId
            };

            dbContext.Commits.Add(commit);
            dbContext.SaveChanges();
        }

        public void DeleteCommit(string id)
        {
           var commit = dbContext
                .Commits
                .FirstOrDefault(c => c.Id == id);

            dbContext.Commits.Remove(commit);
            dbContext.SaveChanges();
        }

        public List<CommitListingViewModel> GetCommits(string ownerId)
        {
            return dbContext
                    .Commits
                    .Where(c => c.CreatorId == ownerId)
                    .Select(c => new CommitListingViewModel
                    {
                        Id = c.Id,
                        RepositoryName = c.Repository.Name,
                        Description = c.Description,
                        CreatedOn = c.CreatedOn.ToString("r", CultureInfo.InvariantCulture)
                    })
                    .ToList();
        }

        public RepoInfoModel GetRepoForCommit(string repoId)
        {
            return dbContext
                    .Repositories
                    .Where(c => c.Id == repoId)
                    .Select(c => new RepoInfoModel
                    {
                        Id= c.Id,
                        Name = c.Name,
                    })
                    .FirstOrDefault();

        }
    }
}
