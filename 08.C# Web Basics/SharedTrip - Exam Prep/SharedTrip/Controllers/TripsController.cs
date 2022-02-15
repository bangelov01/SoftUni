namespace SharedTrip.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using SharedTrip.Contracts;
    using SharedTrip.Models.Errors;
    using SharedTrip.Models.Trips;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly ITripService tripService;
        private readonly IValidatorService validatorService;

        public TripsController(Request request,
            ITripService tripService,
            IValidatorService validatorService)
            : base(request)
        {
            this.tripService = tripService;
            this.validatorService = validatorService;
        }

        [Authorize]
        public Response All()
        {
            var trips = tripService.GetAllTrips();

            return View(trips);
        }

        [Authorize]
        public Response Add() => View();

        [Authorize]
        [HttpPost]
        public Response Add(TripListingFormModel model)
        {
            var errors = validatorService.ValidateTripListing(model);

            if (errors.Any())
            {
                return View(errors, "/Errors");
            }

            tripService.AddTrip(model);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response Details(string tripId)
        {
            var trip = tripService.GetTripById(tripId);

            return View(trip);
        }

        [Authorize]
        public Response AddUserToTrip(string tripId)
        {
            if (validatorService.IsUserAlreadyInTrip(tripId, this.User.Id))
            {
                return Redirect($"/Trips/Details?tripId={tripId}");
            }

            if (!validatorService.AreTripSeatsFree(tripId))
            {
                return View(new ErrorViewModel
                {
                    ErrorMessage = "No available seats in car!"
                }, "/Error");
            }

            tripService.AddUserToTrip(tripId, this.User.Id);

            return Redirect("/Trips/All");
        }
    }
}
