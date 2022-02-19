namespace SMS.Models.Users
{
    using System.Collections.Generic;

    using SMS.Models.Products;

    public class LoggedInUserViewModel
    {
        public string Username { get; set; }

        public string UserCartId { get; set; }

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
