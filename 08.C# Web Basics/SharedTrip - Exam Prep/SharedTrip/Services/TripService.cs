namespace SharedTrip.Services
{
    using SharedTrip.Contracts;

    using SharedTrip.Data.Common;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripService : ITripService
    {
        private readonly IRepository repository;

        public TripService(IRepository repository)
        {
            this.repository = repository;
        }

        public void AddTrip(TripListingFormModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description =  model.Description,
                Seats = model.Seats,
                ImagePath = model.ImagePath
            };

            repository.Add(trip);
            repository.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var trip = repository
                     .Single<Trip>()
                     .Find(tripId);

            trip.Seats -= 1;

            var tripUser = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            repository.Add(tripUser);
            repository.SaveChanges();
        }

        public ICollection<TripViewModel> GetAllTrips()
        {
            return repository
                      .Many<Trip>()
                      .Select(x => new TripViewModel
                      {
                          Id = x.Id,
                          StartPoint = x.StartPoint,
                          EndPoint = x.EndPoint,
                          Seats = x.Seats,
                          DepartureTime = x.DepartureTime.ToString("MM.dd.yyyy HH:mm", CultureInfo.InvariantCulture)
                      })
                      .ToList();
        }

        public TripDetailsViewModel GetTripById(string Id)
        {
            return repository
                      .Many<Trip>()
                      .Where(x => x.Id == Id)
                      .Select(x => new TripDetailsViewModel
                      {
                          Id = x.Id,
                          StartPoint = x.StartPoint,
                          EndPoint = x.EndPoint,
                          DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                          Seats = x.Seats,
                          Description = x.Description,
                      })
                      .FirstOrDefault();
        }
    }
}
