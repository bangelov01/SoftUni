namespace CarShop.Models.Issues
{
    using System.Collections.Generic;

    public class CarIssuesViewModel
    {
        public string Id { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public IEnumerable<IssueListingViewModel> Issues { get; set; }
    }
}
