// Max Weber
// API Analytics
// 1/31/2022
// This is my own work. https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-9.php was largely referenced for the sort

using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;
using AlgorithmSite.APISorting.SortInterface;

namespace AlgorithmSite.APISorting.Quicksort
{
    public class QuickSorter<T> : ISorter<T>
    {
        public static int Iterations { get; set; }

        public QuickSorter()
        {
            Iterations = 0;
        }
        public List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            try
            {
                //
                if (list == null || list.Count <= 0)
                {
                    throw new IndexOutOfRangeException("No items included in list");
                }

                QuickSortGen(list, 0, list.Count - 1);
                return list;
            }
            catch(IndexOutOfRangeException e)
            {
                return null;
            }
            return new List<T>();
        }

        public void QuickSortGen<T>(List<T> list, int start, int end) where T : IComparable<T>
        {

        }

        public T PartitionGen<T>(List<T> list, int start, int end) where T : IComparable<T>
        {
            return list[0];
        }

        //Sorts a default list of 100 random numbers and sorts them using a quicksort
        public async Task<List<int>> SortNewNumList(RandomNumList rLister)
        {
            List<int> nums = await rLister.GetListAsync();
            SortNums(nums, 0, nums.Count-1);
            return nums;
        }
        //Sorts a default list of 100 random words and sorts them using a quicksort
        public async Task<List<string>> SortNewWordList(RandomWordList rLister)
        {
            List<string> words = await rLister.GetListAsync();
            SortWords(words, 0, words.Count-1);
            return words;
        }

        public void SortNums(List<int> nums, int start, int end)
        {
            if(start < end)
            {
                int pivot = PartitionNums(nums, start, end);

                if(pivot > 1)
                {
                    SortNums(nums, start, pivot - 1);
                }
                if(pivot + 1 < end)
                {
                    SortNums(nums, pivot + 1, end);
                }
            }
        }

        public int PartitionNums(List<int> nums, int start, int end)
        {
            int pivot = nums[start];
            while(true)
            {
                while(nums[start] < pivot)
                {
                    Iterations++;
                    start++;
                }
                while(nums[end] > pivot)
                {
                    Iterations++;
                    end--;
                }
                if(start < end)
                {
                    if (nums[start] == nums[end])
                    {
                        return end;
                    }
                    int temp = nums[start];
                    nums[start] = nums[end];
                    nums[end] = temp;
                }
                else
                {
                    return end;
                }
            }
        }

        public void SortWords(List<string> words, int start, int end)
        {
            if (start < end)
            {
                int pivot = PartitionWords(words, start, end);

                if (pivot > 1)
                {
                    SortWords(words, start, pivot - 1);
                }
                if (pivot + 1 < end)
                {
                    SortWords(words, pivot + 1, end);
                }
            }
        }

        public int PartitionWords(List<string> words, int start, int end)
        {
            string pivot = words[start];
            while (true)
            {
                while (words[start].CompareTo(pivot) < 0)
                {
                    Iterations++;
                    start++;
                }
                while (words[end].CompareTo(pivot) > 0)
                {
                    Iterations++;
                    end--;
                }
                if (start < end)
                {
                    if (words[start].CompareTo(words[end]) == 0)
                    {
                        return end;
                    }
                    string temp = words[start];
                    words[start] = words[end];
                    words[end] = temp;
                }
                else
                {
                    return end;
                }
            }
        }
    }
}