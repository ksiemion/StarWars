namespace StarWars.Infrastructure.DTO
{
    public class CharacterDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string[] Episodes { get; set; }
        public string[] Friends { get; set; }
        public string Planet { get; set; }
    }
}
