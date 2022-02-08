// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
namespace AlgorithmSite.APISorting.SortAnalytics
{
    //A class used to hold analysis information based on the efficiency of different sorting algorithms.
    public class AnalysisObj
    {
        //int used to keep track of how many iterations a specific sort or set of sorts has taken to sort given data
        public int Iterations { get; set; }
        //the amount of sorts that occurred
        public int Attempts { get; set; }
        //the type of sort that was done
        public string SortName { get; set; }
        //the average iterations per sort attempt
        public double AvgIterations { get; set; }
        //a list of sorted data containing string representations of sorted data
        public List<List<string>> JsonList { get; set; }
        //Default constructor. Unused at the moment. 
        public AnalysisObj()
        {
            this.SortName = "";
            this.Iterations = 0;
            this.AvgIterations = 0;
            this.Attempts = 0;
            this.JsonList = new List<List<string>>();
        }
        //full-args constructor
        public AnalysisObj(string[] args, List<List<string>> jsonList)
        {
            this.SortName = args[0];
            this.Iterations = int.Parse(args[1]);
            this.Attempts = int.Parse(args[2]);
            this.JsonList = jsonList;
            //sets the average iterations value
            this.AvgIterations = (double)(this.Iterations) / this.Attempts;
        }
    }
}