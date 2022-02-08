using CarShop.Data;
using CarShop.Data.Models;
using CarShop.Models.Issues;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly ApplicationDbContext dbContext;

        public IssueService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateIssue(string description, string carId)
        {
            var issue = new Issue
            {
                Description = description,
                CarId = carId,
            };

            dbContext.Issues.Add(issue);
            dbContext.SaveChanges();
        }


        public void UpdateIssue(string issueId)
        {
            dbContext
              .Issues
              .FirstOrDefault(i => i.Id == issueId)
              .IsFixed = true;

            dbContext.SaveChanges();
        }

        public void DeleteIssue(string issueId)
        {
            var issue = dbContext
                .Issues
                .FirstOrDefault(i => i.Id == issueId);

            dbContext.Issues.Remove(issue);
            dbContext.SaveChanges();
        }

        public CarIdModel GetCarById(string carId)
        {
            return dbContext
                       .Cars
                       .Where(c => c.Id == carId)
                       .Select(c => new CarIdModel
                       {
                           CarId = carId,
                       })
                       .FirstOrDefault();
        }

        public CarIssuesViewModel GetCarWithIssues(string carId)
        {

            return dbContext
                     .Cars
                     .Where(c => c.Id == carId)
                     .Select(i => new CarIssuesViewModel
                     {
                         Id = i.Id,
                         Model = i.Model,
                         Year = i.Year,
                         Issues = i.Issues.Select(x => new IssueListingViewModel
                         {
                             Id = x.Id,
                             Description = x.Description,
                             IsFixed = x.IsFixed
                         })
                     })
                     .FirstOrDefault();
        }

        public bool IsCarOwnedByUser(string carId, string userId)
        {
            return dbContext
                       .Cars
                       .Any(c => c.OwnerId == userId && c.Id == carId);
        }
    }
}
