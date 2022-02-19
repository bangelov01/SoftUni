namespace SMS.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SMS.Contracts;
    using SMS.Models.Carts;

    public class CartsController : Controller
    {
        private readonly IProductService productService;

        public CartsController(IProductService productService)
        {
            this.productService = productService;
        }

        [Authorize]
        public HttpResponse Details(string userCartId)
        {
            var cartModel = new MyCartViewModel
            {
                CartId = userCartId,
                Products = productService.GetAllProductsFromCart(userCartId)
            };

            return View(cartModel);
        }

        [Authorize]
        public HttpResponse AddProduct(string productId, string userCartId)
        {
            productService.AddProductToCart(productId, userCartId);

            return Redirect($"/Carts/Details?userCartId={userCartId}");
        }

        [Authorize]
        public HttpResponse Buy(string userCartId)
        {
            productService.RemoveProductsFromCart(userCartId);

            return Redirect("/Home/IndexLoggedIn");
        }
    }
}
