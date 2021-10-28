using CoreScrapper;
using Newtonsoft.Json;
using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IScrapper scrapper = new Scrapper();
            var result = scrapper.Exrtact(@"Data\task 1 - Kempinski Hotel Bristol Berlin, Germany - Booking.com.html");

            Console.WriteLine(JsonConvert.SerializeObject(result));
        }

        
    }
}
