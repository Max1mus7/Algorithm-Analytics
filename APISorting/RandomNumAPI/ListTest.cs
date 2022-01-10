// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
namespace RandomNumAPI
{
    //Tests the acquisition of random numbers from the API in the RandomNumList() class
    public class ListTest
    {
        //Runs the driver
        public async static Task Main(string[] args)
        {
            //Creates a new RandomNumList object
            RandomNumList rList = new RandomNumList();
            //Gets a list of random numbers from the API
            List<int> freshNums = await rList.GetListAsync();
            //Prints the list of random numbers
            rList.PrintList(freshNums);
            //Console.WriteLine(rList.SetList());
        }

    }
}