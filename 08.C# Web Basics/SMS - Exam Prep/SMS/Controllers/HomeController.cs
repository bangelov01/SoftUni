namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SMS.Contracts;
    using SMS.Models.Users;

    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;

        public HomeController(
            IProductService productService,
            IUserService userService)
        {
            this.productService = productService;
            this.userService = userService;
        }

        public HttpResponse Index() => View();

        [Authorize]
        public HttpResponse IndexLoggedIn()
        {
            var model = new LoggedInUserViewModel
            {
                Username = userService.GetUsername(User.Id),
                UserCartId = userService.GetUserCartId(User.Id),
                Products = productService.GetAllProducts()
            };

            return View(model);
        }
    }
}