using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkWeek2
{
    class Program
    {
        static void Main(string[] args)
        {

      
        }





        public static bool isUgly(int num)
        {
            if( num % 2 == 0)
            {
                num /= 2;
            }
            else if (num % 3 == 0)
            {
                num /= 3;
            }
            else if(num % 5 == 0)
            {
                num /= 5;
            }
            return num == 1;
        }


        //求按从小到大的顺序的第 n 个丑数
        public static int ugly(int n)
        {
            int[] nums = new int[n];
            nums[0] = 1;
            int p2 = 0;
            int p3 = 0;
            int p5 = 0;
            for(int i = 1;i < n; i++)
            {
                nums[i] = Math.Min(Math.Min(nums[p2] * 2, nums[p3] * 3), nums[p5] * 5);
                if (nums[i] == nums[p2] * 2)
                {
                    p2++;
                }
                if (nums[i] == nums[p3] * 3)
                {
                    p3++;
                }
                if (nums[i] == nums[p5] * 5)
                {
                    p5++;
                }
            }
            return nums[n - 1];
        }


        public class Node
        {
            public int val = 0;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        //N叉树的前序
        public static IList<int> NPreorderTraversal(Node root)
        {
            if(root == null)
            {
                return new List<int>();
            }
            List<int> list = new List<int>();
            NPreorder(root, list);
            return list;
        }

        private static void NPreorder(Node node, List<int> list)
        {
            list.Add(node.val);
            for(int i = 0;i< node.children.Count;i++)
            {
                NPreorder(node.children[i], list);
            }
        }


        //N叉树层序
        public static IList<IList<int>> LevelOrder(Node root)
        {
            if(root == null)
            {
                return new List<IList<int>>();
            }
            IList<IList<int>> result = new List<IList<int>>();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while(queue.Count>0)
            {
                List<int> level = new List<int>();
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    Node node = queue.Dequeue();
                    level.Add(node.val);
                    for (int j = 0; j < node.children.Count; j++)
                    {
                        queue.Enqueue(node.children[j]);
                    }

                }
                result.Add(level);
            }
            return new List<IList<int>>(result);
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
        //二叉树前序
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            Preorder(root, list);
            return list;

        }
        private static void Preorder(TreeNode root, List<int> list)
        {
            if(root == null)
            {
                return;
            }
            list.Add(root.val);
            Preorder(root.left, list);
            Preorder(root.right, list);
        }

        //二叉树的中序
        public static IList<int> InorderTraversal(TreeNode root)
        {
            List<int> list = new List<int>();
            Inorder(root, list);
            return list;
        }

        private static void Inorder(TreeNode root,List<int> list)
        {
            if (root == null) return;
            Inorder(root.left,list);
            list.Add(root.val);
            Inorder(root.right,list);

        }



        //有效字母异位词
        public static bool isAnagram(String s, String t)
        {
            if (s.Length != t.Length)
                return false;
            int[] alpha = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                alpha[s[i] - 'a']++;
                alpha[t[i] - 'a']--;
            }
            for (int i = 0; i < 26; i++)
                if (alpha[i] != 0)
                    return false;
            return true;
        }


        //字母异位词分组
        public static IList<IList<string>> GroupAnagrams(String[] strs)
        {
            if (strs == null || strs.Length == 0) return new List<IList<string>>(null);
            Dictionary<string, List<String>> dict = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] ca = new char[26];
                char[] strChar = strs[i].ToCharArray();
                for (int j = 0;j< strChar.Length;j++)
                {
                    ca[strChar[j] - 'a']++;
                }
                string wordstr = new string(ca);
                if (!dict.ContainsKey(wordstr)) dict[wordstr] = new List<string>();
                dict[wordstr].Add(strs[i]);
            }
            return new List<IList<string>>(dict.Values);
        }

        public static IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            Dictionary<string, List<String>> dict = new Dictionary<string, List<string>>();
                for (int i = 0; i < strs.Length; i++)
                {
                    char[] word = strs[i].ToCharArray();
                    Array.Sort(word);
                     string wordstr = new string(word);
                    if(!dict.ContainsKey(wordstr)) dict[wordstr] = new List<string>();
                    dict[wordstr].Add(strs[i]);
                }
            return new List<IList<string>>(dict.Values); 
        }


        //public static void generate(int level,int max,string s)
        //{
        //    if(level == max)
        //    {
        //        Console.WriteLine(s);
        //        return;
        //    }
        //    generate(level + 1, max, s+" a");
        //    generate(level + 1, max, s + " b");
        //    generate(level + 1, max, s + " c");
        //}


    }
}
