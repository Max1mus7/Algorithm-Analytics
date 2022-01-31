// Max Weber
// API Analytics
// 1/31/2022
// This is my own work.

using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;
using AlgorithmSite.APISorting.SortInterface;

namespace Quicksort
{
    public class QuickSorter<T> : ISorter<T>
    {
        public static int Iterations { get; set; }
        public List<T> Sort(List<T> list)
        {
            try
            {
                //
                if (list == null || list.Count <= 0)
                {
                    throw new Exception("No items included in list");
                }
                //checks to see if the list is of an int type
                if (list[0].GetType() == 32.GetType())
                {
                    Console.WriteLine("Worked!i");
                }
                //checks to see if the list is of a string type
                else if(list[0].GetType() == "32".GetType())
                {
                    Console.WriteLine("Worked!s");
                }
                else
                {
                    Console.WriteLine("Failed.");
                }
            }
            catch(Exception e)
            {
                return null;
            }
                return new List<T>();
        }

        //TODO: implement QuickSort
        public async Task<List<int>> SortNewNumList(RandomNumList rLister)
        {
            List<int> nums = await rLister.GetListAsync();
            return nums;
        }
        //TODO: implement QuickSort
        public async Task<List<string>> SortNewWordList(RandomWordList rLister)
        {
            List<string> words = await rLister.GetListAsync();
            return words;
        }
    }
}