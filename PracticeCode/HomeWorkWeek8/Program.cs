using System;

namespace HomeWorkWeek8
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] dataArry = new int[3][];
            dataArry[0] = new int[3];
            dataArry[0][0] = 1;
            dataArry[0][1] = 1;
            dataArry[0][2] = 0;


            dataArry[1] = new int[3];
            dataArry[1][0] = 1;
            dataArry[1][1] = 1;
            dataArry[1][2] = 0;



            dataArry[2] = new int[3];
            dataArry[2][0] = 0;
            dataArry[2][1] = 0;
            dataArry[2][2] = 1;

            FindCircleNum(dataArry);

        }

        public static int FindCircleNum(int[][] m)
        {
            int n = m.Length;
            UnionFind uf = new UnionFind(n);
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    Console.WriteLine(i.ToString()+" "+j.ToString());
                    if (m[i][j] == 1)
                    {
                        uf.meger(i, j);
                    }
                }
            }
            return uf.count;
            Console.ReadKey();
        }
    }






    class UnionFind
    {
        public int[] parent;
        public int count;


        public UnionFind(int n)
        {
            parent = new int[n];
            count = n;
            for(int i = 0; i < n; i++)
            {
                parent[i] = i;
            }
        }

        public int Find(int p)
        {
            
            while(parent[p] != p)
            {
                p = parent[p];
            }

            return p;
        }

       

        public void meger(int p,int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;
            parent[p] = q;
            count--;

        }
    }



}


