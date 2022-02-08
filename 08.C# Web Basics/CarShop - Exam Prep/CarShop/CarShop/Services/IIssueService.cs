namespace CarShop.Services
{
    using CarShop.Models.Issues;
    using System.Collections.Generic;

    public interface IIssueService
    {
        bool IsCarOwnedByUser(string carId, string userId);

        CarIssuesViewModel GetCarWithIssues(string carId);

        CarIdModel GetCarById(string carId);

        void DeleteIssue(string issueId);

        void UpdateIssue(string issueId);

        void CreateIssue(string description, string carId);
    }
}
