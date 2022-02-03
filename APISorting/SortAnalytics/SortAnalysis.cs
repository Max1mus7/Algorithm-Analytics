// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
using SelectionSort;
using AlgorithmSite.APISorting.InsertionSort;
using AlgorithmSite.APISorting.BubbleSort;
using AlgorithmSite.APISorting.RandomNumAPI;
using AlgorithmSite.APISorting.RandomWordAPI;
using Newtonsoft.Json;
using AlgorithmSite.APISorting.SortInterface;
using AlgorithmSite.APISorting.Quicksort;
using AlgorithmSite.APISorting.MergeSort;

namespace AlgorithmSite.APISorting.SortAnalytics
{
    //This class performs analysis on various sorting algorithms
    //Currently, only default sorts are available
    //In the future, sorting with custom data will be supported.
    public class SortAnalysis
    {
        ISorter<int>? numSorter;
        ISorter<string>? wordSorter;
        //Performs a set of selection sorts on default randomized data and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultNumSelectionAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type SelectionSorter
            numSorter = new SelectionSorter<int>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomNumList rLister = new RandomNumList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for(int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<int> sortedList = await numSorter.SortNewNumList(rLister);
                List<string> listItems = new List<string>();
                foreach(int item in sortedList)
                {
                    listItems.Add(item + "");
                }
                sortedLists.Add(listItems);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the SelectionSorter
            int iterations = SelectionSorter<int>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] {"Selection Sort", "" + iterations, "" + attempts}, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }
        //Performs a set of selection sorts on default randomized words and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultWordSelectionAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type SelectionSorter
            wordSorter = new SelectionSorter<string>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomWordList rLister = new RandomWordList();
            //declares and instantiates a new list to hold lists of strings which hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for(int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<string> sortedList = await wordSorter.SortNewWordList(rLister);
                sortedLists.Add(sortedList);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the SelectionSorter
            int iterations = SelectionSorter<string>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] {"Selection Sort", "" + iterations, "" + attempts}, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }
        //Performs a set of insertion sorts on default randomized data and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultNumInsertionAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type InsertionSorter
            numSorter = new InsertionSorter<int>();
            //declares and instantiates a new object of type RandomNumList to generate random numbers form the API
            RandomNumList rLister = new RandomNumList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for(int i = 0; i < attempts; i++)
            {
                //declares a list to hold the sorted list of random numbers and instantiates it
                List<int> sortedList = await numSorter.SortNewNumList(rLister);
                List<string> listItems = new List<string>();
                foreach(int item in sortedList)
                {
                    listItems.Add(item + "");
                }
                sortedLists.Add(listItems);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declares an int to hold the Iterations value from the InsertionSorter
            int iterations = InsertionSorter<int>.Iterations;
            //declares and instantiates a new AnalysisObj object given the information from the sort
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] {"Insertion Sort", "" + iterations, "" + attempts}, sortedLists);
            //returns the AnalysisObj
            return analyzedSorts;
        }
        //Performs a set of insertion sorts on default randomized words and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultWordInsertionAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type InsertionSorter
            wordSorter = new InsertionSorter<string>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomWordList rLister = new RandomWordList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for(int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<string> sortedList = await wordSorter.SortNewWordList(rLister);
                sortedLists.Add(sortedList);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the SelectionSorter
            int iterations = InsertionSorter<string>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] {"Insertion Sort", "" + iterations, "" + attempts}, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }
        //Performs a set of bubble sorts on default randomized data and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultNumBubbleAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type BubbleSorter
            numSorter = new BubbleSorter<int>();
            //declares and instantiates a new object of type RandomNumList to generate random numbers form the API
            RandomNumList rLister = new RandomNumList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for(int i = 0; i < attempts; i++)
            {
                //declares a list to hold the sorted list of random numbers and instantiates it
                List<int> sortedList = await numSorter.SortNewNumList(rLister);
                List<string> listItems = new List<string>();
                foreach(int item in sortedList)
                {
                    listItems.Add(item + "");
                }
                sortedLists.Add(listItems);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declares an int to hold the Iterations value from the InsertionSorter
            int iterations = BubbleSorter<int>.Iterations;
            //declares and instantiates a new AnalysisObj object given the information from the sort
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] {"Bubble Sort", "" + iterations, "" + attempts}, sortedLists);
            //returns the AnalysisObj
            return analyzedSorts;
        }
        //Performs a set of bubble sorts on default randomized words and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultWordBubbleAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type BubbleSorter
            wordSorter = new BubbleSorter<string>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomWordList rLister = new();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for(int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<string> sortedList = await wordSorter.SortNewWordList(rLister);
                sortedLists.Add(sortedList);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the SelectionSorter
            int iterations = BubbleSorter<string>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] {"Bubble Sort", "" + iterations, "" + attempts}, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }

        //Performs a set of quicksorts on default randomized data and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultNumQuicksortAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type QuickSorter
            numSorter = new QuickSorter<int>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomNumList rLister = new RandomNumList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for (int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<int> sortedList = await numSorter.SortNewNumList(rLister);
                List<string> listItems = new List<string>();
                foreach (int item in sortedList)
                {
                    listItems.Add(item + "");
                }
                sortedLists.Add(listItems);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the QuickSorter
            int iterations = QuickSorter<int>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] { "Quick Sort", "" + iterations, "" + attempts }, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }

        //Performs a set of quicksorts on default randomized data and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultWordQuicksortAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type QuickSorter
            wordSorter = new QuickSorter<string>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomWordList rLister = new RandomWordList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for (int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<string> sortedList = await wordSorter.SortNewWordList(rLister);
                sortedLists.Add(sortedList);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the QuickSorter
            int iterations = QuickSorter<string>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] { "Quick Sort", "" + iterations, "" + attempts }, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }

        //Performs a set of merge sorts on default randomized data and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultNumMergeAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type QuickSorter
            numSorter = new MergeSorter<int>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomNumList rLister = new RandomNumList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for (int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<int> sortedList = await numSorter.SortNewNumList(rLister);
                List<string> listItems = new List<string>();
                foreach (int item in sortedList)
                {
                    listItems.Add(item + "");
                }
                sortedLists.Add(listItems);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the QuickSorter
            int iterations = MergeSorter<int>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] { "Merge Sort", "" + iterations, "" + attempts }, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }

        //Performs a set of merge sorts on default randomized data and returns an AnalysisObj object containing the result
        public async Task<AnalysisObj> GetDefaultWordMergeAnalysis()
        {
            //number of sorts is 100 by default
            int attempts = 100;
            //instantiates a new sorter of type QuickSorter
            wordSorter = new MergeSorter<string>();
            //declares and instantiates a new default RandomNumList object to get random numbers from an API
            RandomWordList rLister = new RandomWordList();
            //declares and instantiates a new list to hold the string representations of each sorted list
            List<List<string>> sortedLists = new List<List<string>>();
            for (int i = 0; i < attempts; i++)
            {
                //sorts a new list
                List<string> sortedList = await wordSorter.SortNewWordList(rLister);
                sortedLists.Add(sortedList);
                //rLister.PrintList(sortedList);
                Console.WriteLine("Sort complete!");
            }
            //declare an int to hold the iteration count from the QuickSorter
            int iterations = MergeSorter<string>.Iterations;
            //Declares and instantiates an AnalysisObj object given the information from the sorts
            AnalysisObj analyzedSorts = new AnalysisObj(new string[] { "Merge Sort", "" + iterations, "" + attempts }, sortedLists);
            //returns the AnalysisObj object
            return analyzedSorts;
        }
    }
}