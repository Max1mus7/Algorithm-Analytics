// Max Weber
// API Analytics
// 1/31/2022
// This is my own work.

using AlgorithmSite.APISorting.SortInterface;
using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;

namespace MergeSort
{
    public class MergeSorter<T> : ISorter<T>
    {
        //TODO: implement MergeSort
        public List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            throw new NotImplementedException();
        }

        //TODO: implement MergeSort
        public async Task<List<int>> SortNewNumList(RandomNumList rLister)
        {
            List<int> nums = await rLister.GetListAsync();
            return nums;
        }

        //TODO: implement MergeSort
        public async Task<List<string>> SortNewWordList(RandomWordList rLister)
        {
            List<string> words = await rLister.GetListAsync();
            return words;
        }
    }
}