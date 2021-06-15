using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeWorkWeek4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }



        public static int islandNum(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        dfsFind(grid, i, j);
                        count++;
                    }
                }
            }
            return count;
        }

        private static void dfsFind(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == '0') return;
            grid[i][j] = '0';
            dfsFind(grid, i, j + 1);
            dfsFind(grid, i, j - 1);
            dfsFind(grid, i - 1, j);
            dfsFind(grid, i + 1, j);
        }


        public static bool CanJump(int[] nums)
        {
            if (nums == null) return false;
            int begin = -1;
            int reachable = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] + i > reachable)
                {
                    reachable = i;
                }
            }
            return reachable == 0;
        }


        public static bool CanJump2(int[] nums)
        {
            if (nums == null) return false;
            int maxJumpStep = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (maxJumpStep < i) return false;
                maxJumpStep = Math.Max(maxJumpStep, nums[i] + i);
            }
            return true;

        }


        public static void bfs(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                int count = queue.Count;
                IList<int> list = new List<int>();
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = queue.Dequeue();
                    list.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if(node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                result.Add(list);
            }


        }


    }
      public class TreeNode
      {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(TreeNode left, TreeNode right,int val)
        {
            this.left = left;
            this.right = right;
            this.val = val;
        }

      }
 

}
