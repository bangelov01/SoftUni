using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> products;

        public ProductStock()
        {
            this.products = new List<IProduct>();
        }

        public IProduct this[int index] 
        { 
            get => products[index]; 
        }

        public int Count => this.products.Count;

        public void Add(IProduct product)
        {
            if (products.Any( p => p.Label == product.Label))
            {
                throw new InvalidOperationException("There is already an item with this label!");
            }

            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            if (this.products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public IProduct Find(int index)
        {
            if (index >= 0 && index < products.Count)
            {
                return products[index];
            }

            throw new IndexOutOfRangeException("Index is out of range!");
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            var result = products.Where(p => p.Price == price).ToList();

            return result;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInRange(decimal low, decimal high)
        {
            var result = products.Where(p => p.Price >= low && p.Price <= high).OrderByDescending(p => p).ToList();

            return result;
        }

        public IProduct FindByLabel(string label)
        {
            var searchedProduct = products.FirstOrDefault(p => p.Label == label);

            if (searchedProduct != null)
            {
                return searchedProduct;
            }

            throw new ArgumentException("Such product does not exist!");
        }

        public IProduct FindMostExpensiveProduct()
        {
            var expectedProduct = products.OrderByDescending(p => p.Price).First();

            return expectedProduct;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in products)
            {
                yield return product;
            }
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
