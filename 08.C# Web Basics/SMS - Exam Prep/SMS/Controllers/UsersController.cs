namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SMS.Contracts;
    using SMS.Models.Users;

    public class UsersController : Controller
    {
        private readonly IValidatorService validatorService;
        private readonly IUserService userService;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(
            IValidatorService validatorService,
            IUserService userService,
            IPasswordHasher passwordHasher)
        {
            this.validatorService = validatorService;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            if (string.IsNullOrEmpty(model.Username)
             || string.IsNullOrEmpty(model.Password))
            {
                return Error("Password/Username can not be empty!");
            }

            var userId = userService.GetUserId(model.Username,
                         passwordHasher.HashPassword(model.Password));

            if (userId == null)
            {
                return Error("Username and password combination is not valid!");
            }

            this.SignIn(userId);

            return Redirect("/Home/IndexLoggedIn");
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var errors = validatorService.ValidateUserRegistration(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            userService.CreateUser(model.Username,
                model.Email,
                passwordHasher.HashPassword(model.Password));

            return Redirect("/Users/Login");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
