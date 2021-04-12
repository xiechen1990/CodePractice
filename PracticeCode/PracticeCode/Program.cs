using System;
using System.Collections.Generic;

namespace PracticeCode
{
    class Program
    {
        static void Main(string[] args)
        {

            plusOne(new int[1] { 9});
        }



        public static Array plusOne(int[] digits)
        {
            for(int i = digits.Length - 1; i>= 0; i --)
            {
                if(digits[i] == 9)
                {
                    digits[i] = 0;
                }
                else
                {
                    digits[i] += 1;
                    return digits;
                }
            }
            digits = new int[digits.Length + 1];
            digits[0] = 1;
            return digits;

        }





        public static int RemoveDuplicates(int[] nums)
        {
            if(nums == null || nums.Length == 0) return 0;
            int i = 0;
            int j = 1;
            while( j < nums.Length)
            {
                
                if(nums[i] != nums[j])
                {
                    if(i-j>1)
                    {
                        nums[i + 1] = nums[j];
                        i++;
                    }
                }
                j++;
            }

            return i + 1;
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }


        public static ListNode MergeLink(ListNode l1, ListNode l2)
        {
            if(l1 == null)
            {
                return l2;
            }
            else if(l2 == null)
            {
                return l1;
            }
            else if(l1.val > l2.val)
            {
                l2.next = MergeLink(l1,l2.next);
                return l2;
            }
            else if(l1.val < l2.val)
            {
                l1.next = MergeLink(l1.next, l2);
                return l1;
            }
            return null;
          
        }



        public static void movezros(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    for (int j = i; j < nums.Length - 1; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                    nums[nums.Length - 1] = 0;
                    i = 0;
                }
            }
        }



        public static void MergeArray2(int[] nums1, int m, int[] nums2, int n)
        {
            for(int i = 0; i< n-1; i++)
            {
                nums1[m + i] = nums2[i];
            }
            Array.Sort(nums1);
        }

        public static void MergeArray(int[] nums1, int m, int[] nums2, int n)
        {
            int len1 = m - 1;
            int len2 = n - 1;
            int len = m +n - 1;

            while(len1 >= 0 && len2 >= 0)
            {
                nums1[len--] = nums2[len2] > nums1[len1] ? nums2[len2--] : nums1[len1--];
            }
            
             Array.Copy(nums2, 0, nums1,0,len2+1);
        }




        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int value;
                if (dict.TryGetValue(target - nums[i], out value))
                {
                    return new int[] { value, i };
                }
                else
                {
                    dict.Add(nums[i], i);
                }
            }
            return null;

        }



       public static void Rotatenums(int[] nums,int k)
        {
            if (nums.Length < k) k = nums.Length;
            swapArr(nums, 0,nums.Length - 1);
            swapArr(nums, 0, k-1);
            swapArr(nums, k, nums.Length - 1);
        }


        public static void swapArr(int[] arr,int start,int end)
        {
            while(start<end)
            {
                int temp;
                temp = arr[end];
                arr[start++] = arr[end];
                arr[end--] = temp;
            }

        }
        


      
    }
}
