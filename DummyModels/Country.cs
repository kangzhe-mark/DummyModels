namespace DummyModels
{
    public class Country : IEntity
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string Abbreviation { get; set; }
    }
}