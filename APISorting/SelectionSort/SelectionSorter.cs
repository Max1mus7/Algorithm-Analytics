// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;
using AlgorithmSite.APISorting.SortInterface;
namespace SelectionSort
{
    //This class can be used to sort a list of type T using a selection sort and get a number that indicates the sort's efficiency.
    public class SelectionSorter<T> : ISorter<T>
    {
        //Declares an int used to hold the value of loop iterations a set of sorts takes to complete
        public static int Iterations { get; set; }

        //Sets the Iterations value to 0 every time that a new instance of the class is created.
        public SelectionSorter()
        {
            Iterations = 0;
        }
        //Sorts a list of type T using a Selection Sort 
        //Returns the sorted list.
        public List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            List<T> resultList = new List<T>();
            return resultList;
        }
        //Sorts a list of randomly generated numbers acquired from an API
        //returns the sorted list
        public async Task<List<int>> SortNewNumList(RandomNumList rLister)
        {
            //gets the list of ints from the API and creates a new List object that holds int items
            List<int> newList = await rLister.GetListAsync();
            //performs a selection sort
            int minValIndex = 0;
            for (int i = 0; i < newList.Count; i++)
            {
                minValIndex = i;
                for (int j = i; j < newList.Count; j++)
                {
                    if (newList[j] < newList[minValIndex])
                    {
                        minValIndex = j;
                    }
                    //Counts the amount of iterations the selection sort takes to complete
                    Iterations++;
                }
                int temp = newList[i];
                newList[i] = newList[minValIndex];
                newList[minValIndex] = temp;
            }
            //Returns the sorted list.
            return newList;
        }
        //Sorts a list of randomly generated numbers acquired from an API
        //returns the sorted list
        public async Task<List<string>> SortNewWordList(RandomWordList rLister)
        {
            //gets the list of ints from the API and creates a new List object that holds int items
            List<string> newList = await rLister.GetListAsync();
            //performs a selection sort
            int minValIndex = 0;
            for (int i = 0; i < newList.Count; i++)
            {
                minValIndex = i;
                for (int j = i; j < newList.Count; j++)
                {
                    if (newList[j].CompareTo(newList[minValIndex]) < 0)
                    {
                        minValIndex = j;
                    }
                    //Counts the amount of iterations the selection sort takes to complete
                    Iterations++;
                }
                string temp = newList[i];
                newList[i] = newList[minValIndex];
                newList[minValIndex] = temp;
            }
            //Returns the sorted list.
            return newList;
        }
    }
}