// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace AlgorithmSite.APISorting.RandomNumAPI
{
    //A class used to generate a list of random numbers from an API
    public class RandomNumList 
    {
        //Declares and initializes a nullable List of integers
        List<int>? Nums {get; set;}
        //Sets the list of numbers
        private async Task SetListAsync()
        {
            //declares and initializes the list of ints that will hold the API results
            List<int>? result = new List<int>();
            //Declares and initializes the object that will create an HTTP connection and get an HTTP response.
            HttpClient client = new HttpClient();
            //initializes the Nums list as a blank List of type int
            Nums = new List<int>();
            //Exception handling
            try
            {
                //Clears the default request headers to be used by the HttpClient
                client.DefaultRequestHeaders.Accept.Clear();
                //Adds a header specifying that the request should return a JSON response
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Gets the response from the API and stores it in a new HttpResponseMessage object
                HttpResponseMessage response = await client.GetAsync("http://www.randomnumberapi.com/api/v1.0/random?min=0&max=10000&count=100");
                //Ensures the API connection was successful
                response.EnsureSuccessStatusCode();
                //Deserializes the response String and turns it into a List of type int
                result = JsonConvert.DeserializeObject<List<int>>(await response.Content.ReadAsStringAsync());
                //checks to see if the API response was null
                if(result != null)
                {
                    for(int i = 0; i < result.Count; i++)
                    {
                        Nums.Add(result[i]);
                    }
                }
                else
                {
                    //Throws an exception if there was a null response.
                    throw new Exception("The API returned a null value.");
                }
            }
            //Handles HTTP request-related exceptions
            catch(HttpRequestException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            //Handles all non-HTTP request-related exceptions.
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
        //Gets a new list of numbers from the API
        public async Task<List<int>> GetListAsync()
        {
            await this.SetListAsync();
            if(Nums != null)
            {
                return Nums;
            }
            else
            {
                throw new Exception("The API returned a null value.");
            }
        }
        //Prints a list of any type in a neat format
        public void PrintList(dynamic list)
        {
            int count = 0;
            foreach(var item in list)
            {
                if(count % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(item + "\t");
                count++;
            }
        }
    }
}