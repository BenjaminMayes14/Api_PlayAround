using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Api_PlayAround
{
    internal class Program
    {
        // create new action object
        private static HttpClient client = new HttpClient();

        private static async Task Main(string[] args)
        {
            // create implicitly typed object 
            var user = new
            {
                name = "Ted"
            };

            // convert to JSON file object
            string jsonContent =
                JsonSerializer.Serialize(user);

            //=================Beginning-Line=================================================

            Console.WriteLine("Hello, World!");

            // Add additional GitHub headers
            client.DefaultRequestHeaders.Add("User-Agent", "MyApp");

            // set authentication information for action
            var token = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            await BasicGetAsync("https://api.github.com/user");

            await BasicPostAsync(jsonContent, "https://jsonplaceholder.typicode.com/users");
        }

        private static async Task BasicGetAsync(string url)
        {
            // run GET using action
            HttpResponseMessage response = 
                await client.GetAsync(url);

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

            // convert JSON to local class object 
            Student? person = JsonSerializer.Deserialize<Student>(content);
            if (person == null)
                person = new Student();
            Console.WriteLine(
                $"{person.login}\n{person.email}\n{person.bio}");
        }

        private static async Task BasicPostAsync(string user, string url)
        {
            // convert to JSON file object
            var json =
                new StringContent(
                    user,
                    Encoding.UTF8,
                    "application/json");

            // run POST using action 
            var statusResponse =
                await client.PostAsync(url, json);

            // check if POST action was successful 
            if (statusResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine(statusResponse.StatusCode);
            }
        }

        private static async Task ServerGet()
        { }

        private static async Task ServerPost()
        { }

        private static async Task ServerPut()
        { }

        private static async Task ServerDelete()
        { }
    }
}

/// app notes 
/// <>
/// add API for database
/// <>
/// learn git installation and actions
/// learn API server 
/// learn github projects