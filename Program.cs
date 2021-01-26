using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiClient
{


    class Program
    {
        class Joke
        {
            public int id { get; set; }
            public string type { get; set; }
            public string setup { get; set; }
            public string punchline { get; set; }
        }
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync($"https://official-joke-api.appspot.com/random_joke");

            var jokes = await JsonSerializer.DeserializeAsync<Joke>(responseAsStream);

            Console.WriteLine($"The type {jokes.type} setup {jokes.setup} and punchline {jokes.punchline}");

        }
    }
}
