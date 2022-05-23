using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigmapr
{
    internal class Pair
    {
        private int number;
        private int frequency;

        public Pair(int number, int frequency)
        {
            this.number = number;
            this.frequency = frequency;
        }

        public int Number { get => number; set => number = value; }
        public int Frequency { get => frequency; set => frequency = value; }
        public override string ToString()
        {
            return $"{number} {frequency}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType() || !(obj is Pair))
            {
                return false;
            }
            if (this.Number == ((Pair)obj).Number && this.Frequency == ((Pair)obj).Frequency) { return true; }
            else { return false;}
          
        }

        public static bool operator ==(Pair a, Pair b) => a.Equals(b);
        public static bool operator !=(Pair a, Pair b) => !a.Equals(b);

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
