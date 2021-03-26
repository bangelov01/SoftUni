namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ProductStockTests
    {
        private Mock<IProduct> product;
        private ProductStock productStock;

        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock();
        }
        [Test]
        public void When_AddMethodIsCalled_Product_ShouldBeAdded()
        {
            var product = CreateSingleProduct();

            productStock.Add(product);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, productStock.Count);
        }

        [Test]
        public void When_AddMethodIsCalled_WithExistingProductLabel_ShouldThrowException()
        {
            var productOne = CreateSingleProduct();
            productStock.Add(productOne);

            Assert.Throws<InvalidOperationException>(() => productStock.Add(productOne));

        }

        [Test]
        public void When_ContainsIsCalled_WithValidProduct_ShouldReturnTrue()
        {
            var product = CreateSingleProduct();
            productStock.Add(product);

            var result = productStock.Contains(product);

            Assert.IsTrue(result);
        }

        [Test]
        public void When_ContainsIsCalled_WithInvalidProduct_ShouldReturnFalse()
        {
            var products = CreateMultipleProducts();

            AddProductsToStock(products);

            var productToSearch = CreateSingleProduct();

            Assert.IsFalse(productStock.Contains(productToSearch));
        }

        [Test]
        public void When_FindMethodIsCalled_WithValidIndex_ShouldReturnProductAtIndex()
        {
            var products = CreateMultipleProducts();

            AddProductsToStock(products);

            int indexOfSearchedProduct = products.Count / 2;

            var expectedResult = products[indexOfSearchedProduct];

            var result = productStock.Find(indexOfSearchedProduct);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void When_FindMethodIsCalled_WithInvalidIndex_ShouldThrowException()
        {
            var product = CreateSingleProduct();
            productStock.Add(product);

            int fakeIndex = 1;

            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(fakeIndex));
        }

        [Test]
        public void When_FindByLabelIsCalled_WithValidLabel_ShouldReturnProduct()
        {
            var product = CreateSingleProduct();

            productStock.Add(product);

            string labelToSearch = product.Label;

            var result = productStock.FindByLabel(labelToSearch);

            Assert.AreEqual(product, result);
        }

        [Test]
        public void When_FindByLabelIsCalled_WithInvalidLabel_ShouldThrowException()
        {
            var product = CreateSingleProduct();

            productStock.Add(product);

            string labelToSearch = "Water";

            Assert.Throws<ArgumentException>(() => productStock.FindByLabel(labelToSearch));

        }

        [Test]
        [TestCase(26,30)]
        [TestCase(40,50)]
        public void When_FindAllInPriceRange_WithValidRange_ReturnsVollectionInDescendingOrder_Else_ReturnsEmptyCollection(decimal lowEnd, decimal highEnd)
        {
            var products = CreateMultipleProducts();

            AddProductsToStock(products);

            var expectedProducts = products.Where(p => p.Price >= lowEnd && p.Price <= highEnd).OrderByDescending(p => p).ToList();

            var result = productStock.FindAllInRange(lowEnd, highEnd);

            CollectionAssert.AreEquivalent(expectedProducts, result);
        }

        [Test]
        [TestCase(25)]
        [TestCase(100)]
        public void When_FindByPriceIsCalled_WithValidPrice_ShouldReturnProducts_Else_ShouldReturnEmptyCollection(decimal inputPrice)
        {
            var products = CreateMultipleProducts();

            products.Add(CreateSingleProduct());

            AddProductsToStock(products);

            var expectedProducts = products.Where(p => p.Price == inputPrice).ToList();

            var result = productStock.FindAllByPrice(inputPrice);

            CollectionAssert.AreEquivalent(expectedProducts, result);
        }

        [Test]
        public void When_FindMostExpensiveIsCalled_ShouldReturn_MostExpensiveProduct()
        {
            var products = CreateMultipleProducts();

            AddProductsToStock(products);

            var expectedProduct = products.OrderByDescending(p => p.Price).First();

            Assert.AreEqual(expectedProduct, productStock.FindMostExpensiveProduct());
        }

        private IProduct CreateSingleProduct()
        {
            product = new Mock<IProduct>();
            product.SetupGet(p => p.Label).Returns("Toy");
            product.SetupGet(p => p.Price).Returns(25m);
            product.SetupGet(p => p.Quantity).Returns(2);

            return product.Object;
        }

        private List<IProduct> CreateMultipleProducts()
        {
            List<IProduct> result = new List<IProduct>();

            int productNumber = 10;

            for (int i = 0; i < productNumber; i++)
            {
                product = new Mock<IProduct>();
                product.SetupGet(p => p.Label).Returns($"Beer{i}");
                product.SetupGet(p => p.Price).Returns(25m + i);
                product.SetupGet(p => p.Quantity).Returns(1 + i);

                result.Add(product.Object);
            }

            return result;
        }

        private void AddProductsToStock(List<IProduct> products)
        {
            foreach (var product in products)
            {
                productStock.Add(product);
            }
        }
    }
}
