using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Api_PlayAround
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            HttpClient client = new HttpClient();
            /*
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer", apikey);
            */
            HttpResponseMessage response = await client.GetAsync(
                "https://jsonplaceholder.typicode.com/users/1"  );

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine(response.StatusCode);
            }

            string content = await response.Content.ReadAsStringAsync();

            Person person = JsonSerializer.Deserialize<Person>(content);
            Console.WriteLine(person.name + " " + person.email);

            //===================================================================
            /*
            var user = new
            {
                name = "Ted"
            };

            string file = JsonSerializer.Serialize(user);

            var content = 
                new StringContent(file, Encoding.UTF8, "application/json");

            await client.PostAsync(url, content);
            */
        }
    }
}

/// app notes 
/// use EF core
/// add database 
/// db = persons 
/// fields = id and name
/// <>
/// add API for database