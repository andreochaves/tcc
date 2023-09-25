namespace QuestAdventure.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int Professor { get; set; }
        public int Materia { get; set; }
        public string Nome { get; set; }
        public int Tentativa { get; set; }
    }
}
