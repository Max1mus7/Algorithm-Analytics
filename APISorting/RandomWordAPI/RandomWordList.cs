// Max Weber
// API Analytics
// 1/7/2022
// This is my own work.
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace AlgorithmSite.APISorting.RandomWordAPI
{
    public class RandomWordList
    {
        public List<string>? Words { get; set; }

        private async Task SetListAsync()
        {
            List<string>? result = new List<string>();
            HttpClient connection = new HttpClient();
            Words = new List<string>();
            try
            {
                connection.DefaultRequestHeaders.Accept.Clear();
                connection.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await connection.GetAsync("https://random-word-api.herokuapp.com/word?number=30&swear=0");
                response.EnsureSuccessStatusCode();
                result = JsonConvert.DeserializeObject<List<string>>(await response.Content.ReadAsStringAsync());
                if (result != null)
                {
                    foreach (string word in result)
                    {
                        Words.Add(word);
                    }
                }
                else
                {
                    throw new Exception("The API returned a null value");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        public async Task<List<string>> GetListAsync()
        {
            await this.SetListAsync();
            if (Words != null)
            {
                return Words;
            }
            else
            {
                throw new Exception("The API returned a null value.");
            }
        }

        public void PrintList(dynamic list)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (count % 10 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write(item + "\t");
                count++;
            }
        }
    }
}