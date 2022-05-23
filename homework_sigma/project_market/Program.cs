using System;

namespace project_market
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Kava", 2, 2);
            Console.WriteLine(product);
            DairyProducts dairy = new DairyProducts(System.DateTime.Now, "WE", 1, 3);
            Console.WriteLine(dairy);
            Meat meat = new Meat(Category.Sort2, Species.chicken, System.DateTime.Now, "Kura", 12, 16);
            Console.WriteLine(meat);
            Storage storage = new Storage();
            storage.Dialogue();
        }
        
    }
}