// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;
namespace AlgorithmSite.APISorting.SortInterface
{
    //An interface used to enforce polymorphism as well as enforce code standards for sorting classes
    public interface ISorter<T>
    {
        //Sorts a list of type T based on the sorting class
        public List<T> Sort<T>(List<T> list) where T : IComparable<T>;
        //Sorts a list of random numbers obtained from an API based on the sorting class
        public Task<List<int>> SortNewNumList(RandomNumList rLister);
        public Task<List<string>> SortNewWordList(RandomWordList rLister);

    }
}