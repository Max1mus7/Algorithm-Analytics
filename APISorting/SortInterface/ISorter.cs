// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
using RandomNumAPI;
using RandomWordAPI;
namespace SortInterface
{
    //An interface used to enforce polymorphism as well as enforce code standards for sorting classes
    public interface ISorter<T>
    {
        //Holds the number of iterations through loops it took for a given sort to complete
        public static int Iterations;
        //Sorts a list of type T based on the sorting class
        public List<T> Sort(List<T> list);
        //Sorts a list of random numbers obtained from an API based on the sorting class
        public Task<List<int>> SortNewNumList(RandomNumList rLister);
        public Task<List<string>> SortNewWordList(RandomWordList rLister);
    }
}