namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Contracts;
    using SharedTrip.Models.Errors;
    using SharedTrip.Models.Users;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidatorService validatorService;
        private readonly IUserService userService;
        private readonly IPasswordHasher passwordHasher;
        public UsersController(Request request,
            IValidatorService validatorService,
            IUserService userService,
            IPasswordHasher passwordHasher)
            : base(request)
        {
            this.validatorService = validatorService;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
        }

        public Response Register() => View();

        [HttpPost]
        public Response Register(RegisterUserFormModel model)
        {
            var modelErrors = validatorService.ValidateUserRegistration(model);

            if (modelErrors.Any())
            {
                return View(modelErrors, "/Errors");
            }

            var concreteError = new ErrorViewModel();

            if (!validatorService.IsEmailAvailable(model.Email))
            {
                concreteError.ErrorMessage = "Email already exists!";

                return View(concreteError, "/Error");
            }

            if (!validatorService.IsUsernameAvailable(model.Username))
            {
                concreteError.ErrorMessage = "Username already exists!";

                return View(concreteError, "/Error");
            }

            userService.CreateUser(model.Username,
                model.Email,
                passwordHasher.HashPassword(model.Password));

            return Redirect("/Users/Login");
        }

        public Response Login() => View();

        [HttpPost]
        public Response Login(LoginUserFormModel model)
        {
            var userId = userService.GetUserId(model.Username,
                passwordHasher.HashPassword(model.Password));

            if (userId == null)
            {
                return View(new ErrorViewModel
                {
                    ErrorMessage = "Username and password combination is not valid!"
                }, "/Error");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
