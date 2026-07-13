using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Api_PlayAround
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //=================Beginning-Line=================================================

            Console.WriteLine("Hello, World!");

            //=================GET-Command====================================================

            // create new action object
            HttpClient client = new HttpClient();

            // Add additional GitHub headers
            client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

            // set authentication information for action
            var token = 
                Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer", token);

            // run GET using action
            HttpResponseMessage response = await client.GetAsync(
                "https://api.github.com/user");

            // check if GET action was successful 
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            // convert response to JSON
            string content = await response.Content.ReadAsStringAsync();
            // Console.WriteLine($"\n\ncontent\n\n{content}\n");

            // convert JSON to local class object 
            Student? person = JsonSerializer.Deserialize<Student>(content);
            // Person? person = JsonSerializer.Deserialize<Person>(content);
            if (person == null) 
                person = new Student()  ;
            Console.WriteLine(
                $"{person.login}\n{person.email}\n{person.bio}"  );

            //=================POST-Command===================================================

            // create implicitly typed object 
            var user = new
            {
                name = "Ted"
            };

            // convert to JSON file object
            string jsonContent = 
                JsonSerializer.Serialize(user);
            var json = 
                new StringContent(
                    jsonContent, 
                    Encoding.UTF8,
                    "application/json"  );

            // run POST using action 
            var satusResponse = 
                await client.PostAsync("https://jsonplaceholder.typicode.com/users", json);

            // check if POST action was successful 
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }
        }
    }
}

/// app notes 
/// <>
/// add API for database
/// <>
/// learn git installation and actions
/// learn API server 
/// learn github projects