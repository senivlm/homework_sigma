using System;

namespace project_market
{
    internal partial class Program
    {
        public static class Check
        {
            public static void ShowInfo(Buy buy)
            {
                for (int i = 0; i < buy.ProductsAmount; i++)
                {
                    Console.WriteLine("{0} grn, {1} kg, {2} name", buy.AllProducts[i].Price,
                      buy.AllProducts[i].Weight, buy.AllProducts[i].Name);
                }
                Console.WriteLine("Total price: {0}", buy.TotalPrice);
            }
            public static string Info(Buy buy)
            {
                string str = "";
                for (int i = 0; i < buy.ProductsAmount; i++)
                {
                    str += $"{buy.AllProducts[i].Price}, {buy.AllProducts[i].Weight}, {buy.AllProducts[i].Name}\n";
                }
                str += $"{buy.TotalPrice}";
                return str;
            }

        }
    }
}