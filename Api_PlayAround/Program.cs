using System.Runtime.CompilerServices;

namespace Api_PlayAround
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            HttpClient client = new HttpClient();

            string response = await client.GetStringAsync(
                "https://jsonplaceholder.typicode.com/users/1"      );

            Console.WriteLine(response);
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