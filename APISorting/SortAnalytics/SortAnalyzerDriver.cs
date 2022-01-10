using Newtonsoft.Json;
namespace SortAnalytics
{
// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
    public class SortAnalyzerDriver
    {
        public async static Task Main(string[] args)
        {
            //Declares and instantiates a new default SortAnalysis object
            SortAnalysis sAnalysis = new SortAnalysis();
            //Declares and instantiates a new AnalysisObj object to hold selection sort analysis
            AnalysisObj aObject = await sAnalysis.GetDefaultNumSelectionAnalysis();
            //turns the AnalysisObj into a JSON string
            string objString = JsonConvert.SerializeObject(aObject);
            //Prints the JSON information
            Console.WriteLine(objString);
        }
    }
}