
using System;

namespace DummyModels
{
    class Program
    {
        static void Main(string[] args)
        {
            var country = new DummyBuilder<Country>()
                .WithProperty(t => t.Id, 3)
                .WithProperty(c => c.Name, "United States")
                .WithProperty(c => c.Abbreviation, "US")
                .Build();
            
            Console.WriteLine(country.Name);
        }
    }
}