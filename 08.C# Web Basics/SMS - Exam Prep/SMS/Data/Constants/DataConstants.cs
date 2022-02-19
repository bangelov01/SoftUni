namespace SMS.Data.Constants
{
    public class DataConstants
    {
        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 6;
        public const int PasswordMaxLength = 20;

        public const int ProductNameMinLength = 4;
        public const int ProductNameMaxLength = 20;

        public const string PriceMinValue = "0.05";
        public const string PriceMaxValue = "1000";

        public const string EmailValidationRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
    }
}
