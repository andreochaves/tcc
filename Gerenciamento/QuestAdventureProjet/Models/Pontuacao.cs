namespace QuestAdventure.Models
{
    public class Pontuacao
    {
        public int Id { get; set; }
        public int Aluno { get; set; }
        public int Avaliacao { get; set; }
        public int PontuacaoMaxima { get; set; }
        public string PontoFase { get; set; }
    }

    public class PontuacaoNomes
    {
        public int Id { get; set; }
        public string Aluno { get; set; }
        public string Avaliacao { get; set; }
        public int PontuacaoMaxima { get; set; }
        public string PontoFase { get; set; }
    }
}
