// Max Weber
// API Analytics
// 1/31/2022
// This is my own work. Referenced merge sort at https://www.geeksforgeeks.org/merge-sort/ for this class

using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;
using AlgorithmSite.APISorting.SortInterface;

namespace AlgorithmSite.APISorting.MergeSort
{
    public class MergeSorter<T> : ISorter<T>
    {

        public static int Iterations { get; set; }

        public MergeSorter()
        {
            Iterations = 0;
        }

        //TODO: implement MergeSort
        public List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            throw new NotImplementedException();
        }

        public async Task<List<int>> SortNewNumList(RandomNumList rLister)
        {
            List<int> nums = await rLister.GetListAsync();
            SortNums(nums, 0, nums.Count - 1);
            return nums;
        }

        //TODO: implement MergeSort
        public async Task<List<string>> SortNewWordList(RandomWordList rLister)
        {
            List<string> words = await rLister.GetListAsync();
            SortWords(words, 0, words.Count - 1);
            return words;
        }

        public void MergeNums(List<int> nums, int l, int m, int r)
        {
            //Iterations++;
            //Define indices needed in order to merge subLists
            int s1 = m - l + 1;
            int s2 = r - m;

            //Create new lists to hold the split array
            int[] left = new int[s1];
            int[] right = new int[s2];
            int i;
            int j;
            //split into subarrays(subLists)
            for (i = 0; i < s1; ++i)
            {
                left[i] = nums[l + i];
            }
            for (i = 0; i < s2; ++i)
            {
                right[i] = nums[m + 1 + i];
            }
            //reset i index
            i = 0;
            j = 0;
            int k = l;
            //merge subLists
            while (i < s1 && j < s2)
            {

                if (left[i] <= right[j])
                {
                    nums[k] = left[i];
                    i++;
                    Iterations++;
                }
                else
                {
                    nums[k] = right[j];
                    j++;
                    Iterations++;
                }
                k++;
            }

            // Copy remaining elements
            // of left[] if any
            while (i < s1)
            {
                nums[k] = left[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of right[] if any
            while (j < s2)
            {
                nums[k] = right[j];
                j++;
                k++;
            }
        }

        public void SortNums(List<int> nums, int l, int r)
        {

            if (l < r)
            {
                int m = l + (r - l) / 2;
                //split the nums list into two halves
                SortNums(nums, l, m);
                SortNums(nums, m + 1, r);

                MergeNums(nums, l, m, r);
            }
        }

        public void MergeWords(List<string> words, int l, int m, int r)
        {
            //Iterations++;
            //Define indices needed in order to merge subLists
            int s1 = m - l + 1;
            int s2 = r - m;

            //Create new lists to hold the split array
            string[] left = new string[s1];
            string[] right = new string[s2];
            int i;
            int j;
            //split into subarrays(subLists)
            for (i = 0; i < s1; ++i)
            {
                left[i] = words[l + i];
            }
            for (i = 0; i < s2; ++i)
            {
                right[i] = words[m + 1 + i];
            }
            //reset i index
            i = 0;
            j = 0;
            int k = l;
            //merge subLists
            while (i < s1 && j < s2)
            {

                if (left[i].CompareTo(right[j]) <= 0)
                {
                    words[k] = left[i];
                    i++;
                    Iterations++;
                }
                else
                {
                    words[k] = right[j];
                    j++;
                    Iterations++;
                }

                k++;
            }

            // Copy remaining elements
            // of left[] if any
            while (i < s1)
            {
                words[k] = left[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of right[] if any
            while (j < s2)
            {
                words[k] = right[j];
                j++;
                k++;
            }
        }

        public void SortWords(List<string> words, int l, int r)
        {

            if (l < r)
            {
                int m = l + (r - l) / 2;
                //split the nums list into two halves
                SortWords(words, l, m);
                SortWords(words, m + 1, r);

                MergeWords(words, l, m, r);
            }
        }
    }
}