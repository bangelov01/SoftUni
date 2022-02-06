namespace CarShop.Services
{
    using CarShop.Models.Cars;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICarService
    {
        void CreateCar(string model,
            int year,
            string image,
            string plateNumber,
            string ownerId);

        List<CarListingViewModel> GetUserCars(string userId);

        List<CarListingViewModel> GetCarsWithIssues();
    }
}
