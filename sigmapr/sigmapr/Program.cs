using System;

namespace sigmapr
{
	class Program
	{
		static void Main(string[] args)
		{
            //Pair pair1 =null;
            //Pair pair2 = new Pair(3, 2);

            //Console.WriteLine(pair1.Equals(pair2));
            //Console.WriteLine(ReferenceEquals(pair1, pair2));



            //Vector arr1 = new Vector(10);
            //arr1.InitRand(1, 5);
            //try {
            //    arr1[0] = int.MaxValue;
            //    Console.WriteLine(arr1[12]);
            //}
            //catch (IndexOutOfRangeException e)

            //    Console.WriteLine(e.Message);
            //}

            //Pair[] arr2 = arr1.CalculateFreq();
            //for (int i = 0; i < arr2.Length; i++)
            //{
            //    Console.Write(arr2[i]+"\n");
            //}
            //Console.WriteLine()

            Matrix matrix = new();
            matrix.buildDiagonalSnake(6, Direction.Up);
            matrix.buildDiagonalSnake(6, Direction.Down);


        }
    }
}

