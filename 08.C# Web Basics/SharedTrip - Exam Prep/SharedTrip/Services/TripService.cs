namespace SharedTrip.Services
{
    using SharedTrip.Contracts;
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TripService : ITripService
    {
        private readonly ApplicationDbContext dbContext;

        public TripService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
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

            dbContext.Trips.Add(trip);
            dbContext.SaveChanges();
        }

        public ICollection<TripViewModel> GetAllTrips()
        {
            return dbContext
                      .Trips
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
            return dbContext
                      .Trips
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
