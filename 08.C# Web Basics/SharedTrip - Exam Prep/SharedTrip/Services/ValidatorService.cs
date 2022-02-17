namespace SharedTrip.Services
{
    using SharedTrip.Contracts;
    using SharedTrip.Data.Common;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Errors;
    using SharedTrip.Models.Trips;
    using SharedTrip.Models.Users;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using static Data.Constants.DataConstants;

    public class ValidatorService : IValidatorService
    {
        private readonly IRepository repository;

        public ValidatorService(IRepository repository)
        {
            this.repository = repository;
        }

        public bool IsEmailAvailable(string email)
        {
            if (this.repository
                .Many<User>()
                .Any(u => u.Email == email))
            {
                return false;
            }

            return true;
        }

        public bool IsUsernameAvailable(string username)
        {
            if (this.repository.
                Many<User>().
                Any(u => u.Username == username))
            {
                return false;
            }

            return true;
        }

        public ICollection<ErrorViewModel> ValidateTripListing(TripListingFormModel model)
        {
            var errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(model.StartPoint)
                || string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = "StartPoint/EndPoint can not be empty!"
                });
            }

            if (!DateTime.TryParseExact(model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = "DepartureDate not in the correct format!"
                });
            }

            if (model.Seats < SEATS_MIN_VALUE
                || model.Seats > SEATS_MAX_VALUE)
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = $"Seats must be between {SEATS_MIN_VALUE} and {SEATS_MAX_VALUE}!"
                });
            }

            if (model.Description.Length > TRIP_DESCRIPTION_MAX_VALUE)
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = $"Description length must be below {TRIP_DESCRIPTION_MAX_VALUE} characters long!"
                });
            }

            return errors;
        }

        public bool AreTripSeatsFree(string tripId)
        {
            var seatNumber = repository
                                .Single<Trip>()
                                .Find(tripId)
                                .Seats;

            if (seatNumber < 1)
            {
                return false;
            }

            return true;
        }

        public bool IsUserAlreadyInTrip(string tripId,
            string userId)
        {
            var userTrip = repository
                         .Many<UserTrip>()
                         .Where(t => t.UserId == userId 
                                  && t.TripId == tripId)
                         .FirstOrDefault();

            if (userTrip == null)
            {
                return false;
            }

            return true;
        }

        public ICollection<ErrorViewModel> ValidateUserRegistration(RegisterUserFormModel model)
        {
            var errors = new List<ErrorViewModel>();

            if (model.Username.Length < USERNAME_MIN_LENGTH
                || model.Username.Length > USERNAME_MAX_LENGTH)
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = $"Username must be between {USERNAME_MIN_LENGTH} and {USERNAME_MAX_LENGTH} characters long!"
                });
            }

            if (model.Password.Length < PASSWORD_MIN_LENGTH
                || model.Password.Length > PASSWORD_MAX_LENGTH)
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = $"Password length must be between {PASSWORD_MIN_LENGTH} and {PASSWORD_MAX_LENGTH}!"
                });
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = $"Email cannot be empty!"
                });
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add(new ErrorViewModel
                {
                    ErrorMessage = "Password and Confirm Password do not match!"
                });
            }

            return errors;
        }
    }
}
