using System;
using System.Linq;

namespace sigmapr
{
    class Vector
    {
        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= array.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else { return array[i]; }
               
            }
            set
            {
                array[i] = value; 
            }
        }

        int[] array;
        Random rnd = new Random();
        public Vector(int n)
        {
            array = new int[n];
        }
        public void InitRand(int a, int b)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(a,b);
            }
        }
        public void InitShuffle()
        {
            int index;
            for (int i = 0; i < array.Length; i++)
            {
                for (index = rnd.Next(1, array.Length + 1); Array.Exists(array, number => number == index); index = rnd.Next(1, array.Length + 1))
                {
                    array[i] = index;
                }
            }
            //for (int i = 0; i < array.Length; i++)
            //{
            //    while (true)
            //    {
            //        r = random.Next(1, array.Length + 1);
            //        bool isexist = false;
            //        for (int j = 0; j < i; j++)
            //        {
            //            if (array[j] == r)
            //            {
            //                isexist = true;
            //                break;
            //            }
            //        }
            //        if (!isexist)
            //        {
            //            array[i] = r;
            //            break;
            //        }
            //    }
            //}
        }
        public Pair[] CalculateFreq()
        {
            Pair[] pairs = new Pair[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                pairs[i] = new Pair(0, 0);
            }
            int countDifference = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0 / i + 1 ; j < countDifference; j++)
                {

                    if (array[i] == pairs[j].Number)
                    {
                        pairs[j].Frequency++;
                        isElement = true;
                        break;
                    }

                }
                if (!isElement)
                {
                    pairs[countDifference].Number = array[i];
                    pairs[countDifference].Frequency++;
                    countDifference++;

                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = new Pair(pairs[i].Number, pairs[i].Frequency);
                //result[i].Number = pairs[i].Number;
                //result[i].Freq = pairs[i].Freq;
            }
            return result;

        }
        public bool IsPalidrome()
        {
            bool isPalidrome = true;
            for (int i = 0; i < array.Length / 2; i++)
            {
                if (array[i] != array[array.Length - i - 1])
                {
                    isPalidrome = false;
                }
            }
            return isPalidrome;
        }
        public void ModifyReverse()
        {
            int temp;
            for (int i = 0; i < array.Length / 2; i++)
            {
                temp = array[i];
                array[i] = array[array.Length - i - 1];
                array[array.Length - i - 1] = temp;
            }
        }
        public Pair LongestSeq()
        {
            Pair longestSeq;
            int frequence = 1;
            int number = array[0];
            int logestFrequence = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] != array[i - 1])
                {
                    frequence = 0;
                }
                frequence++;
                if (frequence > logestFrequence)
                {
                    logestFrequence = frequence;
                    number = array[i];
                }
            }
            longestSeq = new Pair(number, logestFrequence);
            return longestSeq;
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < array.Length; i++)
            {
                s += array[i] + " ";
            }
            return s;
        }
    }
}
