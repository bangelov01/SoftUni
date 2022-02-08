namespace CarShop.Controllers
{
    using CarShop.Models.Issues;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class IssuesController : Controller
    {
        private readonly IUserService userService;
        private readonly IIssueService issueService;

        public IssuesController(IUserService userService, IIssueService issueService)
        {
            this.userService = userService;
            this.issueService = issueService;
        }

        public HttpResponse Add(string carId)
        {
            var car = issueService.GetCarById(carId);

            return View(car);
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddIssueFormModel model)
        {
            issueService.CreateIssue(model.Description, model.CarId);

            return Redirect($"/Issues/CarIssues?carId={model.CarId}");
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {

            if (!userService.IsUserMechanic(this.User.Id))
            {

                if (!issueService.IsCarOwnedByUser(carId, this.User.Id))
                {
                    return Error("You do not have access to this vehicle!");
                }
            }

            var car = issueService.GetCarWithIssues(carId);

            if (car == null)
            {
                return Error("Car does not exist!");
            }

            return View(car);
        }

        [Authorize]
        public HttpResponse Fix(string issueId, string carId)
        {
            if (!userService.IsUserMechanic(this.User.Id))
            {
                return Error("You are not authorized to fix issues!");
            }

            issueService.UpdateIssue(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            issueService.DeleteIssue(issueId);

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
