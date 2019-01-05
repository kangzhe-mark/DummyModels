namespace FixtureBuilder.Models
{
    public class Pet
    {
        protected Pet(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}