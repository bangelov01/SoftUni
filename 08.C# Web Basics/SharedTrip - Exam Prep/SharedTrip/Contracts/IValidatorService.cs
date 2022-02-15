namespace SharedTrip.Contracts
{
    using SharedTrip.Models.Errors;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System.Collections.Generic;
    public interface IValidatorService
    {
        ICollection<ErrorViewModel> ValidateUserRegistration(RegisterUserFormModel model);

        ICollection<ErrorViewModel> ValidateTripListing(TripListingFormModel model);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);

        bool AreTripSeatsFree(string tripId);

        bool IsUserAlreadyInTrip(string tripId, string userId);
    }
}
