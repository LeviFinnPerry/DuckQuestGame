namespace DuckQuest.Models
{
    public class CharacterNameInputModel
    {
        public string Name { get; set; }
    }
    public class CharacterRepository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quickness { get; set; }
        public int Ugly { get; set; }
        public int Arcana { get; set; }
        public int Cool { get; set; }
        public int Kismit { get; set; }
        public int Kudos { get; set; }
        public int Heart { get; set; }
        public int Psyche { get; set; }
        public int Armour { get; set; }
        public string Equipment { get; set; }
        public int TreasureDucats { get; set; }
        public string Pets { get; set; }
        public string Quirks { get; set; }
        public string Quests { get; set; }
    }
}
