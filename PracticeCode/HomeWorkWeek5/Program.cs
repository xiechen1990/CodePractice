using System;
using System.Collections.Generic;

namespace HomeWorkWeek5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            int[][] jaggedArray ={

                    new int[]{1, 3, 1 },

                    new int[] {1, 5, 1},

                    new int[] { 4, 2, 1 }

                    };

            MinPathSum2(jaggedArray);
        }



        public static int MinDistance(string word1, string word2)
        {
            int n = word1.Length;
            int m = word2.Length;
            int[,] dp = new int[n + 1, m + 1];
            for (int i = 0; i < n + 1; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j < m + 1; j++)
            {
                dp[0, j] = j;
            }
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < m + 1; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j - 1], dp[i - 1, j]), dp[i, j - 1]) + 1;
                    }
                }
            }
            return dp[n, m];
        }

        public static int MinPathSum(int[][] grid)
        {
            int n = 3;
            int m = grid[0].Length;

            int[,] dp = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 && j == 0) continue;
                    if (i == 0)
                    {
                        dp[i, j] = dp[i, j - 1] + grid[i][j];
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + grid[i][j];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                    }
                }
            }
            return dp[n - 1, m - 1];
        }




    }
}
