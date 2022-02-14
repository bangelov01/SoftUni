namespace SharedTrip.Contracts
{
    using SharedTrip.Models.Trips;
    using System.Collections.Generic;

    public interface ITripService
    {
        ICollection<TripViewModel> GetAllTrips();

        void AddTrip(TripListingFormModel model);

        TripDetailsViewModel GetTripById(string Id);
    }
}
