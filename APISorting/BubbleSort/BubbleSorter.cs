// Max Weber
// API Analytics
// 1/7/2022
// I used source code from the following websites to complete this assignment: www.geeksforgeeks.com/bubble-sort
using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;
using AlgorithmSite.APISorting.SortInterface;

namespace AlgorithmSite.APISorting.BubbleSort
{
    //This typed class contains methods from the ISorter interface.
    //This class will perform a bubble sort on either input data or random data from an API
    public class BubbleSorter<T> : ISorter<T>
    {
        //Keeps track of how many iterations have occured in a number of consecutive sorts
        public static int Iterations { get; set; }
        //Every time a new instance of this class is initialized, reset the Iterations counter
        public BubbleSorter()
        {
            Iterations = 0;
        }
        /*This method performs a bubble sort on a list of type T. Returns the sorted list.
        * ***This method is not properly implemented yet***
        */
        public List<T> Sort<T>(List<T> list) where T : IComparable<T>
        {
            List<T> resultList = new List<T>();
            return resultList;
        }

        /*This method performs a bubble sort on a list of random numbers acquired from an API.
        * This method is async due to the fact that it requires a response from a site to function.
        * Returns the sorted list.
        * Takes a RandomNumList object as a parameter to be used to acquire random data.
        */
        public async Task<List<int>> SortNewNumList(RandomNumList rLister)
        {
            //Gets randomly generated list of numbers from API.
            //See RandomNumList class for more information.
            List<int> nums = await rLister.GetListAsync();
            //performs a bubble sort on list of ints
            //the following sort is from GeeksForGeeks.com
            int n = nums.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                        Iterations++;
                    }
                }
            }
            //returns sorted list
            return nums;
        }
        /*This method performs a bubble sort on a list of random words acquired from an API.
        * This method is async due to the fact that it requires a response from a site to function.
        * Returns the sorted list.
        * Takes a RandomWordList object as a parameter to be used to acquire random data.
        */
        public async Task<List<string>> SortNewWordList(RandomWordList rLister)
        {
            //Gets randomly generated list of words from API.
            //See RandomWordList class for more information.
            List<string> words = await rLister.GetListAsync();
            //performs a bubble sort on list of strings
            //the following sort is inspired by the sort on GeeksForGeeks.com
            int n = words.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        // swap temp and arr[i]
                        string temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                        Iterations++;
                    }
                }
            }
            //returns sorted list
            return words;
        }
    }
}