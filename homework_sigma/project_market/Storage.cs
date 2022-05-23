using System;
using System.Collections.Generic;

namespace project_market
{
    internal partial class Program
    {
        public class Storage
        {
            protected List<Product> products { get; private set; } = new List<Product>();
            public Storage(params Product[] products)
            {
                foreach (var item in products)
                {
                    this.products.Add(item);
                }
            }
            public Product this[int i]
            {
                get
                {
                    return products[i];
                }
            }
            public void Dialogue()
            {
                var productsInStock = new Dictionary<string, Product>();
                productsInStock["1"] = new Product("Apple", 5, 0.5d);
                productsInStock["2"] = new Product("Cake", 50, 1d);
                productsInStock["3"] = new Product("Lemon", 10, 0.3d);
                productsInStock["4"] = new Meat(Category.Sort2, Species.chicken, System.DateTime.Today.AddDays(10), "Chicken", 130, 1);
                productsInStock["5"] = new Meat(Category.HighSort1, Species.pork, System.DateTime.Today.AddDays(15), "Pork", 150, 1);

                do
                {
                    Console.WriteLine("What do you want to buy?");

                    for (int i = 1; i <= productsInStock.Count; i++)
                    {
                        Console.WriteLine($"{i} - {productsInStock[i.ToString()].Name}");
                    }
                    Console.WriteLine($"{productsInStock.Count + 1} -Exit ");
                    string answer;
                    do
                    {
                        answer = Console.ReadLine();
                    } while (!productsInStock.ContainsKey(answer) && answer != (productsInStock.Count + 1).ToString());

                    if (answer == (productsInStock.Count + 1).ToString())
                    {
                        Console.WriteLine($"Products count: {products.Count}");
                        break;
                    }
                    else
                    {
                        products.Add(productsInStock[answer]);
                        Console.WriteLine($"Products count: {products.Count}");
                    }
                } while (true);
            }

            public void FindAllMeat()
            {
                foreach (var item in products)
                {
                    if (item is Meat)
                    {
                        Console.WriteLine("Meat named {0} was found", item.Name);
                    }
                }
            }

            public void ChangePriceOfAllProducts(int percentage)
            {
                foreach (var item in products)
                {
                    item.ChangePrice(percentage);
                }
            }

        }
    }
}