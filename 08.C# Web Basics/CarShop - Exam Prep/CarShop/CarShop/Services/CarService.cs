namespace CarShop.Services
{
    using CarShop.Data;
    using CarShop.Data.Models;
    using CarShop.Models.Cars;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CarService : ICarService
    {
        private readonly ApplicationDbContext dbContext;
        public CarService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateCar(string model,
            int year,
            string image,
            string plateNumber,
            string ownerId)
        {
            var car = new Car
            {
                Model = model,
                Year = year,
                PictureUrl = image,
                PlateNumber = plateNumber,
                OwnerId = ownerId
            };

            dbContext.Cars.AddAsync(car);
            dbContext.SaveChangesAsync();
        }

        public List<CarListingViewModel> GetCarsWithIssues()
        {
            return dbContext
                       .Cars
                       .Where(c => c.Issues.Any(i => !i.IsFixed))
                        .Select(c => new CarListingViewModel
                        {
                            Id = c.Id,
                            Model = c.Model,
                            Year = c.Year,
                            Image = c.PictureUrl,
                            PlateNumber = c.PlateNumber,
                            FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                            RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count()
                        })
                       .ToList();
        }

        public List<CarListingViewModel> GetUserCars(string userId)
        {
            return dbContext
                       .Cars
                       .Where(c => c.OwnerId == userId)
                       .Select(c => new CarListingViewModel
                       {
                           Id = c.Id,
                           Model = c.Model,
                           Year = c.Year,
                           Image = c.PictureUrl,
                           PlateNumber = c.PlateNumber,
                           FixedIssues = c.Issues.Where(i => i.IsFixed).Count(),
                           RemainingIssues = c.Issues.Where(i => !i.IsFixed).Count()
                       })
                       .ToList();
        }
    }
}
