using System;
using FixtureBuilder;
using FixtureBuilder.Models;
using Xunit;

namespace FixtureBuilderTest
{
    public class DynamicBuilderTest
    {
        [Fact]
        public void should_set_property()
        {
            dynamic countryBuilder = new DynamicFixtureBuilder<Country>();
            countryBuilder.Name = "China";
            Country country = countryBuilder.Build();
            Assert.Equal("China", country.Name);
        }

        [Fact]
        public void should_set_long_property_with_int_value()
        {
            dynamic countryBuilder = new DynamicFixtureBuilder<Country>();
            countryBuilder.Id = 3;

            Country country = countryBuilder.Build();
            Assert.Equal(3, country.Id);
        }

        [Fact]
        public void should_not_set_non_existing_property()
        {
            dynamic countryBuilder = new DynamicFixtureBuilder<Country>();
            Assert.ThrowsAny<Exception>(() => { countryBuilder.A = 123; });
        }

        [Fact]
        public void should_not_set_string_property_with_number_value()
        {
            dynamic countryBuilder = new DynamicFixtureBuilder<Country>();
            Assert.ThrowsAny<Exception>(() => { countryBuilder.Name = 123; });
        }

        [Fact]
        public void should_set_property_with_derived_instance()
        {
            dynamic builder = new DynamicFixtureBuilder<Owner>();
            builder.Pet = new Cat("Mocha");

            Owner owner = builder.Build();
            Assert.Equal("Mocha", owner.Pet.Name);
        }
    }
}