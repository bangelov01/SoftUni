namespace Git.Services
{
    using Git.ViewModels.Commits;
    using System.Collections.Generic;
    public interface ICommitService
    {
        void CreateCommit(string description,
            string ownerId,
            string repoId);

        List<CommitListingViewModel> GetCommits(string ownerId);

        void DeleteCommit(string id);

        RepoInfoModel GetRepoForCommit(string repoId);
    }
}
