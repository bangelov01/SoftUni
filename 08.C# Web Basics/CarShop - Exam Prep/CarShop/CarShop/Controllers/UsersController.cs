namespace CarShop.Controllers
{
    using CarShop.Data.Models;
    using CarShop.Models.Users;
    using CarShop.Data.Common;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;
    using CarShop.Data;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext dbContext;

        public UsersController(IValidator validator,
            IUserService userService,
            IPasswordHasher passwordHasher,
            ApplicationDbContext dbContext)
        {
            this.validator = validator;
            this.dbContext = dbContext;
            this.userService = userService;
            this.passwordHasher = passwordHasher;
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = validator.ValidateUserRegistration(model);

            if (!userService.IsUsernameAvailable(model.UserName))
            {
                modelErrors.Add($"Username {model.UserName} already exists!");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            userService.CreateUser(model.UserName,
                model.Email,
                this.passwordHasher.HashPassword(model.Password),
                model.UserType);

            return Redirect("/Users/Login");
        }

        public HttpResponse Login() => View();

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var userId = userService.GetUserId(model.Username,
                passwordHasher.HashPassword(model.Password));

            if (userId == null)
            {
                return Error("Username and password combination is not valid!");
            }

            this.SignIn(userId);

            return Redirect("/Cars/All");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}
