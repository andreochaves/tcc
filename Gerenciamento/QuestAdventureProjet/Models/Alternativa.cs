using System.Collections.Generic;

namespace QuestAdventure.Models
{
	public class Alternativas
	{
		public int Id { get; set; }
		public int Questao { get; set; }
		public string Alternativa { get; set; }
		public bool Correto { get; set; }
	}
}