namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.Repositories;
    using static Data.Constatnts.DataConstants;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class RepositoriesController : Controller
    {
        private readonly IValidatorService validatorService;
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IValidatorService validatorService,
            IRepositoryService repositoryService)
        {
            this.validatorService = validatorService;
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repos = repositoryService.GetRepositories();

            return View(repos);
        }

        public HttpResponse Create()
        {
            if (!this.User.IsAuthenticated)
            {
                return Error("You are not a User and can not access this page!");
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(RepositoryFormModel model)
        {

            if (!validatorService.ValidateRepositoryCreation(model))
            {
                return Error($"Repository name must be between {REPOSITORY_NAME_MIN_LENGTH} and {REPOSITORY_NAME_MAX_LENGTH}!");
            }

            repositoryService.CreateRepository(model.Name,
                model.RepositoryType,
                this.User.Id);

            return Redirect("/Repositories/All");
        }
    }
}
