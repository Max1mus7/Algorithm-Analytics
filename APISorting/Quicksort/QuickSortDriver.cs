// Max Weber
// API Analytics
// 1/31/2022
// This is my own work.

namespace AlgorithmSite.APISorting.Quicksort
{
    public class QuickSortDriver
    {
        public static void Main(string[] args)
        {
            QuickSorter<int> q = new();
            List<int> nums = new List<int> { 1, 3, 5 };
            q.Sort(nums);
        }
    }
}
