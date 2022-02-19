namespace SMS.Controllers
{
    using System.Linq;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SMS.Contracts;
    using SMS.Models.Products;

    public class ProductsController : Controller
    {
        private readonly IValidatorService validatorService;
        private readonly IProductService productService;
        private readonly IUserService userService;

        public ProductsController(
            IValidatorService validatorService,
            IProductService productService,
            IUserService userService)
        {
            this.validatorService = validatorService;
            this.productService = productService;
            this.userService = userService;
        }

        [Authorize]
        public HttpResponse Create() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateProductFormModel model)
        {
            var errors = validatorService.ValidateProductCreation(model);

            if (errors.Any())
            {
                return Error(errors);
            }

            productService.AddProduct(model.Name, model.Price);

            return Redirect("/Home/IndexLoggedIn");
        }
    }
}
