using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            maxSubSet(nums);

            //List<string> a = new List<string> { "hot", "dot", "dog", "lot", "log", "cog" };
            //ladder("hit","cog", a);

            int[] nums2 = { 1,2,3};
            var a = permute(nums2);

            //Console.WriteLine(permute(nums2));


            for (int i = 0; i < a.Count; i++)
            {
                string s = "";
                for (int j = 0; j < a[i].Count; j++)
                {
                    s += "," + a[i][j];
                }
                Console.WriteLine(s);
            }


            Console.ReadKey();
        }


        //单词接龙
        public static int ladder(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> dictSet = new HashSet<string>(wordList);
            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);

            int maxLen = 1;
            while(queue.Count > 0)
            {
                int size = queue.Count;
                for(int i = 0; i < size; i ++)
                {
                    string word = queue.Dequeue();
                    char[] ch = word.ToCharArray();
                    for(int j = 0; j < ch.Length; j ++)
                    {
                        for (char c = 'a'; c < 'z'; c++)
                        {
                            if(ch[j] == c)
                            {
                                continue;
                            }
                            ch[j] = c;
                            string target = String.Join("",ch);
                            if (dictSet.Contains(target) && visited.Add(target))
                            {
                                if(endWord.Equals(target))
                                {
                                    return maxLen + 1;
                                }
                                queue.Enqueue(target);
                            }
                        }
                    }
                }
                maxLen++;
            }
            return 0;

        }




        public static int maxSubSet(int[] nums)
        {
            int[] dp = nums;
            for(int i = 1; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i - 1], 0) + nums[i];
            }
           return  dp.Max();

        }


        //子序列
        private static IList<IList<int>> res = new List<IList<int>>();
        public static IList<IList<int>> subSets(int[] nums)
        {
            if (nums == null) return res;
            IList<int> list = new List<int>();
            backtrack(nums, list, 0);
            return res;
        }


        private static void backtrack(int[] nums, IList<int> list, int level)
        {
            res.Add(new List<int>(list));
            for (int start = level; start < nums.Length; start++)
            {
                //if(start > 0 && nums[start] == nums[start - 1])  //如果包含重复元素的NUMS
                //{
                //    continue;   
                //}
                list.Add(nums[start]);
                backtrack(nums, list, start + 1);
                list.Remove(nums[start]);
            }
        }


        //1-N数字的K个组合
        private static IList<IList<int>> res2 = new List<IList<int>>();
        public static IList<IList<int>> combine(int n , int k)
        {
            IList<int> list = new List<int>();
            backtrack2(n, k,list, 0);
            return res;
        }

        private static void backtrack2(int n , int k , IList<int> list,int level)
        {
            if (list.Count == k)
            {
                res2.Add(new List<int>(list));
            }

            for(int start = level; start < n;start ++)
            {
                list.Add(start);
                backtrack2(n, k, list, start+1);
                list.Remove(start);
            }
        }


        //全排列
        private static IList<IList<int>> res3 = new List<IList<int>>();
        private static int[] visited;
        private static IList<IList<int>> permute(int[] nums)
        {
            if (nums == null) return null;
            IList<int> list = new List<int>();
            Array.Sort(nums);
            visited = new int[nums.Length];
            backtrack3(nums, list);
            return res3;
        }


        private static void backtrack3(int[] nums, IList<int> list)
        {
            if(list.Count == nums.Length)
            {
                res3.Add(new List<int>(list));
            }
            for(int i = 0; i < nums.Length; i++)
            {

                if (visited[i] == 1) continue;
                // 剪枝
                if (i > 0 && nums[i] == nums[i - 1] && visited[i - 1] == 0) continue;
                visited[i] = 1;
                list.Add(nums[i]);
                backtrack3(nums, list);
                visited[i] = 0;
                list.RemoveAt(list.Count-1);
            }
        }





        //二叉树的最近公共祖先（
        public static TreeNode LowestAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root == null || root == p || root == q)
            {
                return root;
            }
            TreeNode left = LowestAncestor(root.left, p, q);
            TreeNode right = LowestAncestor(root.right, p, q);

            if (left == null && right == null) return null;

            if(left == null)
            {
                return right;
            }
            if (right == null)
            {
                return left;
            }
            return root;
        }



        //从前序与中序遍历序列构造二叉树
        public static TreeNode buildTree(int[] preorder, int[] inorder)
        {
            int prelen = preorder.Length;
            int inlen = inorder.Length;

            if(prelen == 0 || inlen == 0)
            {
                return null;
            }
            Dictionary<int, int> map = new Dictionary<int, int>();
            for(int i = 0; i < inorder.Length; i++)
            {
                map.Add(inorder[i],i);
            }
            TreeNode node = BuildTree(preorder,0,prelen-1,map,0,inlen-1);
            return node;
        }


        private static TreeNode BuildTree(int[] preOrder,int preleft,int preright,Dictionary<int,int> map,int inleft ,int inright)
        {
            if(preleft > preright || inleft > inright)
            {
                return null;
            }
            int root = preOrder[preleft];
            int pindex;
            map.TryGetValue(root, out pindex);
            TreeNode node = new TreeNode(root);

            node.left = BuildTree(preOrder, preleft + 1, pindex - inleft + preleft, map, inleft, pindex - 1);
            node.right = BuildTree(preOrder, pindex - inleft + preleft + 1, preright, map, pindex + 1, inright);
            return node;

        }



        private void invertTree(TreeNode root)
        {
            if (root == null)
                return;

            TreeNode tempNode = root.left;
            root.left = root.right;
            root.right = tempNode;

            invertTree(root.right);
            invertTree(root.leftj);
        }

    }



    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
