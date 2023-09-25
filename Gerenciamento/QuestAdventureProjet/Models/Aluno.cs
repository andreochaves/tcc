using System.Collections.Generic;

namespace QuestAdventure.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public int Professor { get; set; }
        public int Materia { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
