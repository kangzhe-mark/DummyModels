
using System;

namespace FixtureBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var country = BuildCountry();

            Console.WriteLine(country.Name);
        }

        private static Country BuildCountry()
        {
            var country = new FixtureBuilder<Country>()
                .WithProperty(t => t.Id, 3)
                .WithProperty(c => c.Name, "United States")
                .WithProperty(c => c.Abbreviation, "US")
                .Build();
            return country;
        }
    }
}