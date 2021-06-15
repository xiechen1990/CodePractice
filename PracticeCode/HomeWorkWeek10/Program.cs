using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeWorkWeek10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[,] multiDimensionalArray1 = new int[2, 3];
            multiDimensionalArray1[0,1] = 1;

            Console.WriteLine(multiDimensionalArray1);
            Console.ReadLine();
        }

        
        public static int MinPathSum(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            int[,] dp = new int[n,n];

            for(int i = triangle.Count - 2;i >= 0; i ++)
            {
                for(int j = 0; j < triangle[i].Count; j++)
                {

                    dp[i, j] += Math.Min(dp[i + 1, j], dp[i + 1, j + 1]);
                }
            }
            return dp[0, 0];
            Array.Fill(triangle, 12);
        }

        

    }
}
