using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace KanyeRest
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 5; i++)
            {
                KanyeSpeak();
                RonSpeak();                
            }

        }

        public static void KanyeSpeak()
        {
            // Allows us to call the API
            //API URL
            //Stors the JSON response in a variable
            //Parses through the response we recived to get the value associated with
            //the NAME "quote"

            var client = new HttpClient();
            var kanyeURL = "https://api.kanye.rest";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            Console.WriteLine($"Kanye: {kanyeQuote}");

        }
        public static void RonSpeak()
        {
            var client = new HttpClient();
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
            Console.WriteLine($"Ron: {ronQuote}");
        }
    }
}
