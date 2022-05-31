using System;
using System.IO;
using System.Linq;

namespace sigmapr
{
    enum typeOfSort
    {
        Average,
        First,
        Last,
    }
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
                // Індекс теж треба контролювати
                array[i] = value; 
            }
        }

        int[] array;
        Random rnd = new Random();
        // так не можна робити. Конструктор повнісю не підготував екземпляр до роботи.
        public Vector() { }
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

        //public void QuickSortAverage( int firstIndex, int lastIndex)
        //{
        //    int midNumber=array[(firstIndex+lastIndex)/2];
        //    int i=firstIndex, j=lastIndex;
        //    do
        //    {
        //        while (array[j] > midNumber)
        //            j--;
        //        while (array[i] < midNumber)
        //            i++;
        //        if (i <= j)
        //        {
        //            int temp = array[i];
        //            array[i]=array[j];
        //            array[j] = temp;
        //            i++;j--;
        //        }
        //    } while (i <= j);
        //    if (j > firstIndex)
        //    {
        //        QuickSortAverage(firstIndex,j);
        //    }
        //    if (i < lastIndex) 
        //    {
        //        QuickSortAverage(i,lastIndex);
        //    }
        //}
        //public void QuickSortFirst(int firstIndex, int lastIndex)
        //{
        //    int lastNumber = array[firstIndex];
        //    int i = firstIndex, j = lastIndex;
        //    do
        //    {
        //        while (lastNumber < array[j])
        //            j--;
        //        while (lastNumber > array[i])
        //            i++;
        //        if (i <= j)
        //        {
        //            int temp = array[i];
        //            array[i] = array[j];
        //            array[j] = temp;
        //            i++; j--;
        //        }
        //    } while (i <= j);
        //    if (j > firstIndex)
        //    {
        //        QuickSortAverage(firstIndex, j);
        //    }
        //    if (i < lastIndex)
        //    {
        //        QuickSortAverage(i, lastIndex);
        //    }
        //}
        //public void QuickSortLast(int firstIndex, int lastIndex)
        //{
        //    int lastNumber = array[lastIndex];
        //    int i = firstIndex, j = lastIndex;
        //    do
        //    {
        //        while (lastNumber<array[j])
        //            j--;
        //        while (lastNumber > array[i])
        //            i++;
        //        if (i <= j)
        //        {
        //            int temp = array[i];
        //            array[i] = array[j];
        //            array[j] = temp;
        //            i++; j--;
        //        }
        //    } while (i <= j);
        //    if (j > firstIndex)
        //    {
        //        QuickSortAverage(firstIndex, j);
        //    }
        //    if (i < lastIndex)
        //    {
        //        QuickSortAverage(i, lastIndex);
        //    }
        //}

        public void QuickSort(int firstIndex, int lastIndex, typeOfSort t)
        {
           int number=0;
           switch (t)
            {
                case typeOfSort.Average:
                    number = array[(firstIndex + lastIndex) / 2];
                    break;
                case typeOfSort.First:
                    number = array[firstIndex];
                    break;
                case typeOfSort.Last:
                    number = array[lastIndex];
                    break;
            }
            int i = firstIndex, j = lastIndex;
            do
            {
                while (number < array[j])
                    j--;
                while (number > array[i])
                    i++;
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);
            if (j > firstIndex)
            {
                QuickSort(firstIndex, j, t);
            }
            if (i < lastIndex)
            {
                QuickSort(i, lastIndex, t);
            }
        }

        public void Merge(int left, int q, int right)
        {
            int i = left;
            int j = q;
            int[] temp = new int[right-left];
            int k = 0;
            while (i<q&&j<right)
            {
                if (this.array[i] <= this.array[j])
                {
                    temp[k] = this.array[i];
                    i++;
                }
                else
                {
                    temp[k] = this.array[j];
                    j++;
                }
                k++;

            }
            if (i == q)
            {
                for (int m = j; m < right; m++)
                    temp[k++] = this.array[m];
            }
            else 
            {
                while (i < q) 
                    temp[k++] = this.array[i++]; 
            }
            for (int n = 0; n < temp.Length; n++) 
            {
                array[n+left]=temp[n]; 
            } 
        }
        public void SplitMergeSort()
        {
            SplitMergeSort(0,array.Length);
        }
        void SplitMergeSort(int start, int end)
        {
            if (end - start <= 1)
            {
                return;
            }
            int middle = (start + end) / 2;
            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);
            Merge(start, middle, end);
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

        public void ReadFromFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName).ToArray();

            StreamReader reader = new StreamReader(fileName);
            string line = reader.ReadToEnd();
            line.Split(' ');
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
