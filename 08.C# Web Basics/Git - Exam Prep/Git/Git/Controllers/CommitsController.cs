
namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.Commits;
    using static Data.Constatnts.DataConstants;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IValidatorService validatorService;

        public CommitsController(ICommitService commitService,
            IValidatorService validatorService)
        {
            this.commitService = commitService;
            this.validatorService = validatorService;
        }

        public HttpResponse All()
        {
            if (!this.User.IsAuthenticated)
            {
                return Error("You are not a User and can not access this page!");
            }

            var commits = commitService.GetCommits(this.User.Id);

            return View(commits);
        }

        public HttpResponse Create(string Id)
        {
            if (!this.User.IsAuthenticated)
            {
                return Error("You are not a User and can not access this page!");
            }

            var commit = commitService.GetRepoForCommit(Id);

            return View(commit);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CommitFormModel model)
        {

            if (!validatorService.ValidateCommitCreation(model))
            {
                return Error($"Description must be more than {COMMIT_DESCRIPTION_MIN_LENGTH} characters long!");
            }

            commitService.CreateCommit(model.Description,
                this.User.Id,
                model.RepoId);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string Id)
        {
            commitService.DeleteCommit(Id);

            return Redirect("/Commits/All");
        }
    }
}
