using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> savePerson = new List<Person>();
            List<Product> saveProduct = new List<Product>();

            for (int i = 0; i < 2; i++)
            {
                string[] infoArray = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in infoArray)
                {
                    string[] values = item.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string name = values[0];
                    int money = int.Parse(values[1]);

                    try
                    {
                        if (i == 0)
                        {
                            Person person = new Person(name, money);
                            savePerson.Add(person);
                        }
                        else
                        {
                            Product product = new Product(name, money);
                            saveProduct.Add(product);
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Environment.Exit(0);
                    }
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArr = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commandArr[0];
                string product = commandArr[1];

                var currentPerson = savePerson.First(x => x.Name == name);
                var currentProduct = saveProduct.First(x => x.Name == product);

                currentPerson.AddToBag(currentProduct);

            }

            foreach (var kvp in savePerson)
            {
                List<string> productNmaes = new List<string>();

                StringBuilder sb = new StringBuilder();

                if (kvp.Products.Count > 0)
                {
                    foreach (var item in kvp.Products)
                    {
                        productNmaes.Add(item.Name);
                    }

                    sb.Append($"{kvp.Name} - {string.Join(", ", productNmaes)}");
                }
                else
                {
                    sb.Append($"{kvp.Name} - Nothing bought");
                }

                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
