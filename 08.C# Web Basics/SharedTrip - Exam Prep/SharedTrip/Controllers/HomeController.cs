using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models.Users;

namespace SharedTrip.Controllers
{

    public class HomeController : Controller
    {
        
        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index()
        {

            return this.View();
        }
    }
}