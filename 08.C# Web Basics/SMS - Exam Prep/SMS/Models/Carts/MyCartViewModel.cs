namespace SMS.Models.Carts
{
    using System.Collections.Generic;

    using SMS.Models.Products;

    public class MyCartViewModel
    {
        public string CartId { get; set; }
        public ICollection<ProductViewModel> Products { get; set; }
    }
}
