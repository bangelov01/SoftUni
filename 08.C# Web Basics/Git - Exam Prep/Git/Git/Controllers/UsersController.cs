namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.Users;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class UsersController : Controller
    {
        private readonly IValidatorService validatorService;
        private readonly IUsersService usersService;
        private readonly IPasswordHasher passwordHasher;

        public UsersController(IValidatorService validatorService,
            IUsersService usersService,
            IPasswordHasher passwordHasher)
        {
            this.validatorService = validatorService;
            this.usersService = usersService;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = validatorService.ValidateUserRegistration(model);

            if (!usersService.IsUsernameAvailable(model.UserName))
            {
                modelErrors.Add($"Username {model.UserName} already exists!");
            }

            if (!usersService.IsEmailAvailable(model.Email))
            {
                modelErrors.Add($"Email {model.Email} already exists!");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            usersService.CreateUser(model.UserName,
                model.Email,
                this.passwordHasher.HashPassword(model.Password));

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var userId = usersService.GetUserId(model.Username,
                passwordHasher.HashPassword(model.Password));

            if (userId == null)
            {
                return Error("Username and password combination is not valid!");
            }

            this.SignIn(userId);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
