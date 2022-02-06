namespace CarShop.Services
{
    using CarShop.Models.Cars;
    using CarShop.Models.Users;
    using System.Collections.Generic;

    public interface IValidator
    {
        ICollection<string> ValidateUserRegistration(RegisterUserFormModel model);
        ICollection<string> ValidateCarAddition(AddCarFormModel model);
    }
}
