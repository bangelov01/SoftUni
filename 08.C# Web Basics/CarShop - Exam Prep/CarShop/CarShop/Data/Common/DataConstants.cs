namespace CarShop.Data.Common
{
    public class DataConstants
    {
        public const int USERNAME_MIN_LENGTH = 4;
        public const int USERNAME_MAX_LENGTH = 20;

        public const int PASSWORD_MIN_LENGTH = 5;
        public const int PASSWORD_MAX_LENGTH = 20;

        public const int CAR_MODEL_MIN_LENGTH = 5;
        public const int CAR_MODEL_MAX_LENGTH = 20;

        public const string PLATENUMBER_REGEX = @"^[A-Z]{2}[0-9]{4}[A-Z]{2}$";

        public const int ISSUE_MIN_LENGTH = 5;

        public const string USER_CLIENT = "Client";
        public const string USER_MECHANIC = "Mechanic";

    }
}
