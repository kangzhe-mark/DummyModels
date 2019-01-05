namespace FixtureBuilder.Models
{
    public class Owner : IEntity
    {
        public Pet Pet { get; set; }
        public long Id { get; set; }
    }
}