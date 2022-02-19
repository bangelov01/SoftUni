namespace SMS.Contracts
{
    using System.Collections.Generic;

    using SMS.Models.Products;
    using SMS.Models.Users;

    public interface IValidatorService
    {
        ICollection<string> ValidateUserRegistration(RegisterUserFormModel model);
        ICollection<string> ValidateProductCreation(CreateProductFormModel model);
    }
}
