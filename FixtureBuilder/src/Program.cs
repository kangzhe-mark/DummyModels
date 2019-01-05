
using System;
using FixtureBuilder.Models;

namespace FixtureBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
//            var country = BuildCountry();
            var country = DynamicBuildCountry();

            Console.WriteLine(country.Id);
            Console.WriteLine(country.Name);
            Console.WriteLine(country.Abbreviation);
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

        private static Country DynamicBuildCountry()
        {
            dynamic countryBuilder = new DynamicFixtureBuilder<Country>();
            countryBuilder.Name = "United States";
            countryBuilder.Id = 3;
            countryBuilder.Abbreviation = "US";
            
            return countryBuilder.Build();
        }
    }
}