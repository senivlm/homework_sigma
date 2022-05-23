using System;
namespace sigmapr
{
    enum Direction
    {
        Up,
        Down
    }

    class Matrix
    { 
        public void BuildDiagonalSnake(int n, Direction direction)
        {
            int[,] array = new int[n, n];
            int i = 0;
            int j = 0;
            bool isUp = default;

            switch (direction)
            {
                case 0:
                    isUp = true;
                    break;

                case (Direction)1:
                    isUp = false;
                    break;
                default:
                    break;
            }

            for (int k = 1; k < (n * n)+1;)
            {
                if (isUp)
                {
                    for (; i >= 0 && j < n; j++, i--)
                    {
                        array[i, j] = k;
                        k++;
                    }

                    if (i < 0 && j <= n - 1)
                    {
                        i = 0;
                    }
                    if (j == n)
                    {
                        i += 2;
                        j--;
                    }
                }
                else
                {
                    for (; j >= 0 && i < n; i++, j--)
                    {
                        array[i, j] = k;
                        k++;
                    }

                    if (j < 0 && i <= n - 1)
                    {
                        j = 0;
                    }
                    if (i == n)
                    {
                        j += 2;
                        i--;
                    }
                }
                isUp = !isUp;
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}