using System;

namespace PracticeCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int a = fib(5);
            int b = fib2(5);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        static int find(int[] array,int val)
        {
            int startindex = 0;
            int endindex = array.Length - 1;
            while(endindex>startindex)
            {
                int mid = (startindex+endindex)/ 2;
                if(val == array[mid])
                {
                    return array[mid];
                }
                else if(val > array[mid])
                {
                    startindex = mid + 1;
                }
                else if(val < array[mid])
                {
                    endindex = mid - 1;
                }
            }
                return -1;
         }


        static int fib(int n)
        {

            if(n==0)
            {
                return 1;
            }

            return n * fib(n - 1);
        }


        static int fib2(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            int sum = 1 ;
            for(int i=1;i<=n;i++)
            {
                sum = sum * i;
            }
            return sum;
        }
    }
}
