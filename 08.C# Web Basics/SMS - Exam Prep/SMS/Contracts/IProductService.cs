namespace SMS.Contracts
{
    using System.Collections.Generic;

    using SMS.Models.Products;

    public interface IProductService
    {
        void AddProduct(string name,
                        decimal price);

        ICollection<ProductViewModel> GetAllProducts();

        ICollection<ProductViewModel> GetAllProductsFromCart(string userId);

        void AddProductToCart(string productId, string userID);

        void RemoveProductsFromCart(string userID);
    }
}
