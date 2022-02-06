namespace CarShop.Controllers
{
    using CarShop.Models.Cars;
    using CarShop.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly IValidator validator;
        private readonly ICarService carService;
        private readonly IUserService userService;

        public CarsController(IValidator validator, ICarService carService, IUserService userService)
        {
            this.validator = validator;
            this.carService = carService;
            this.userService = userService;
        }

        [Authorize]
        public HttpResponse Add()
        {
            if (userService.IsUserMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddCarFormModel model)
        {
            if (userService.IsUserMechanic(this.User.Id))
            {
                return Unauthorized();
            }

            var modelErrors = validator.ValidateCarAddition(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            carService.CreateCar(model.Model,
                model.Year,
                model.Image,
                model.PlateNumber,
                this.User.Id);

            return Redirect("/Cars/All");

        }

        [Authorize]
        public HttpResponse All()
        {
            var cars = new List<CarListingViewModel>();

            if (userService.IsUserMechanic(this.User.Id))
            {
                cars = carService.GetCarsWithIssues();
            }
            else
            {
                cars = carService.GetUserCars(this.User.Id);
            }

            return View(cars);
        }
    }
}
