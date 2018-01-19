using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MovieApi;
 
namespace ApiCaller
{
    public class WebRequest
    {
        // The second parameter is a function that returns a Dictionary of string keys to object values.
        // If an API returned an array as its top level collection the parameter type would be "Action>"
        // public static async Task GetMovieDataAsync(string movie, Action<Dictionary<string, object>> Callback)
        public static async Task GetMovieDataAsync(string movie, Action<Movie> Callback)        
        {
            JObject jKey = JObject.Parse(File.ReadAllText(@"JsonData/key.json"));
            var apiKey = jKey["Key"];

            // Create a temporary HttpClient connection.
            using (var Client = new HttpClient())
            {
                try
                {
                    Client.BaseAddress = new Uri($"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={movie}");  
                    HttpResponseMessage Response = await Client.GetAsync(""); // Make the actual API call.
                    Response.EnsureSuccessStatusCode(); // Throw error if not successful.
                    string StringResponse = await Response.Content.ReadAsStringAsync(); // Read in the response as a string.
                    
                    JObject MovieObject = JsonConvert.DeserializeObject<JObject>(StringResponse);
                    JArray ResultList = MovieObject["results"].Value<JArray>();                    

                    // foreach (var item in ResultList.Children()) {
                    //     var itemProperties = item.Children<JProperty>();
                    //     // Console.WriteLine(itemProperties);
                    //     var myElement = itemProperties.FirstOrDefault(x => x.Name == "title");
                    //     Console.WriteLine(myElement);
                    //     var myElementValue = myElement.Value;
                    //     // Console.WriteLine(myElementValue);
                    // }

                    Movie MovieData = new Movie {
                        Title = ResultList.Children().First()["title"].Value<string>(),
                        VoteAverage = ResultList.Children().First()["vote_average"].Value<double>(),
                        ReleaseDate = ResultList.Children().First()["release_date"].Value<string>()
                    };

                    // Console.WriteLine(MovieData.Title);
                    // Console.WriteLine(MovieData.VoteAverage);
                    // Console.Write(MovieData.ReleaseDate);

                    // Then parse the result into JSON and convert to a dictionary that we can use.
                    // DeserializeObject will only parse the top level object, depending on the API we may need to dig deeper and continue deserializing
                    Dictionary<string, object> JsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(StringResponse);

                    // Finally, execute our callback, passing it the response we got.
                    // Callback(JsonResponse);
                    Callback(MovieData);
                    
                }
                catch (HttpRequestException e)
                {
                    // If something went wrong, display the error.
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}
