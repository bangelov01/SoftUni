namespace SMS.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using SMS.Contracts;
    using SMS.Data;
    using SMS.Data.Models;
    using SMS.Models.Products;

    public class ProductService : IProductService
    {
        private readonly SMSDbContext dbContext;

        public ProductService(SMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddProduct(string name, decimal price)
        {
            var product = new Product
            {
                Name = name,
                Price = price
            };

            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }

        public void AddProductToCart(string productId, string cartId)
        {
            var product = dbContext
                          .Products
                          .Find(productId);

            var cart = dbContext
                          .Carts
                          .Find(cartId);

            cart.Products.Add(product);

            dbContext.SaveChanges();
        }

        public ICollection<ProductViewModel> GetAllProducts()
        {
            return dbContext
                   .Products
                   .Select(p => new ProductViewModel
                    {
                        ProductId = p.Id,
                        ProductName = p.Name,
                        ProductPrice = p.Price
                    })
                   .ToList();
        }

        public ICollection<ProductViewModel> GetAllProductsFromCart(string cartId)
        {
            var products = dbContext
                           .Products
                           .Where(p => p.CartId == cartId)
                           .Select(p => new ProductViewModel
                           {
                               ProductId = p.Id,
                               ProductName = p.Name,
                               ProductPrice = p.Price
                           })
                           .ToList();

            return products;
        }

        public void RemoveProductsFromCart(string cartId)
        {
            var userProducts = dbContext
                               .Products
                               .Where(p => p.CartId == cartId)
                               .ToList();

            var cart = dbContext
                   .Carts
                   .Where(c => c.Id == cartId)
                   .FirstOrDefault();

            foreach (var p in userProducts)
            {
                cart.Products.Remove(p);
            }

            dbContext.SaveChanges();
        }
    }
}
