using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Tests
{
    [TestFixture]
    public class StoreManagerTests
    {
        private StoreManager storeManager;

        [SetUp]
        public void Setup()
        {
            storeManager = new StoreManager();
        }

        [Test]
        public void When_StoreManagerIsInitiated_CountShouldBeZero()
        {
            int expected = 0;

            Assert.AreEqual(expected, storeManager.Count);
        }

        [Test]
        public void When_AddProductIsCalled_CountShouldIncrease()
        {
            int expected = 1;

            storeManager.AddProduct(CreateSingleProduct());

            Assert.AreEqual(expected, storeManager.Count);
        }

        [Test]
        public void When_AddMethodIsCalled_ProductsShouldBeAdded()
        {
            var products = CreateMultipleProducts();

            foreach (var product in products)
            {
                storeManager.AddProduct(product);
            }

            CollectionAssert.AreEquivalent(products, storeManager.Products);
        }

        [Test]
        public void When_AddMethodIsCalled_WithNullProduct_ShouldThrowException()
        {
            Product product = null;

            Assert.Throws<ArgumentNullException>(() => storeManager.AddProduct(product), nameof(product));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        public void When_AddMethodIsCalled_WithLessThanZeroQuantity_ShouldThrowException(int quantity)
        {
            Product product = new Product("Beef",quantity,10);

            Assert.Throws<ArgumentException>(() => storeManager.AddProduct(product), "Product count can't be below or equal to zero.");
        }

        [Test]
        public void When_BuyProductIsCalled_ShouldReturnFinalPrice()
        {
            var product = CreateSingleProduct();

            storeManager.AddProduct(product);

            int testQuantity = 5;

            decimal expectedFinalPrice = product.Price * testQuantity;

            Assert.AreEqual(expectedFinalPrice, storeManager.BuyProduct(product.Name, testQuantity));
        }

        [Test]
        public void When_BuyProductIsCalled_ProductQuantityShouldReduce()
        {
            var product = CreateSingleProduct();

            storeManager.AddProduct(product);

            int testQuantity = 5;

            int expectedQuantity = product.Quantity - testQuantity;

            storeManager.BuyProduct(product.Name, testQuantity);

            var resultProduct = storeManager.Products.First(p => p.Name == product.Name);

            Assert.AreEqual(expectedQuantity, resultProduct.Quantity);

        }

        [Test]
        public void When_BuyProductIsCalled_WithNonExistantProduct_ShouldThrowException()
        {
            var product = CreateSingleProduct();

            Assert.Throws<ArgumentNullException>(() => storeManager.BuyProduct(product.Name, 2),nameof(product), "There is no such product.");
        }
        [Test]
        public void When_BuyProductIsCalled_WithNotEnoughQuantity_ShouldThrowException()
        {
            var product = CreateSingleProduct();

            storeManager.AddProduct(product);

            int testQuantity = 260;

            Assert.Throws<ArgumentException>(() => storeManager.BuyProduct(product.Name, testQuantity), "There is not enough quantity of this product.");
        }

        [Test]
        public void When_GetTheMostExpensiveProductIsCalled_ShouldReturn_MostExpensivestProduct()
        {
            var products = CreateMultipleProducts();

            foreach (var product in products)
            {
                storeManager.AddProduct(product);
            }

            var expected = products.OrderByDescending(p => p.Price).FirstOrDefault();

            Assert.AreEqual(expected, storeManager.GetTheMostExpensiveProduct());
        }

        [Test]
        public void When_GetTheMostExpensiveProductIsCalled_WithNoProducts_ShouldReturnNull()
        {
            Product expected = null;

            Assert.AreEqual(expected, storeManager.GetTheMostExpensiveProduct());
        }

        private Product CreateSingleProduct()
        {
            return new Product("Coffee", 250, 3.25m);
        }

        private List<Product> CreateMultipleProducts()
        {
            int quantity = 10;

            var result = new List<Product>();

            for (int i = 0; i < quantity; i++)
            {
                Product newProduct = new Product($"Product{i}", 1 + i, 200 + i);
                result.Add(newProduct);
            }

            return result;
        }
    }
}