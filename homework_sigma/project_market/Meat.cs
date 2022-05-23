using System;

namespace project_market
{
    internal partial class Program
    {
        public class Meat : DairyProducts
        {
            public Category MeatCategory { get; }
            public Species MeatSpecies { get; }

            public Meat(Category meatCategory, Species meatSpecies, DateTime date,
              string name, int price, double weight) : base(date, name, price, weight)
            {
                MeatCategory = meatCategory;
                MeatSpecies = meatSpecies;
            }
            public Meat() : this(default, default, default, default, default, default)
            {

            }
            public override void ChangePrice(int percentage)
            {
                switch (MeatCategory)
                {
                    case Category.HighSort1:
                        percentage += 25;
                        break;
                    case Category.Sort2:
                        percentage += 10;
                        break;
                    default:
                        break;
                }
                if (IsExpired())
                {
                    percentage = percentage > 40 ? percentage - 30 : percentage;
                }
                Price = (int)((double)Price * (percentage / 100d));
            }
            public override string ToString()
            {
                return base.ToString() + $", MeatCategory: {MeatCategory}, MeatSpecies: {MeatSpecies}";
            }
            public override bool Equals(object meat)
            {
                return base.Equals(meat) && this.MeatCategory == ((Meat)meat).MeatCategory && this.MeatSpecies == ((Meat)meat).MeatSpecies;
            }
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}