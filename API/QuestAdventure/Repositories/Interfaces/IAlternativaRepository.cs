using QuestAdventureAPI.Models;

namespace QuestAdventureAPI.Repositories.Interfaces
{
	public interface IAlternativaRepository
	{
		Task<List<Alternativas>> BuscarAlternativas();
		Task<Alternativas> BuscarPorId(int alternativaId);
		Task<List<Alternativas>> BuscarPorQuestao(int questao);
		Task<Alternativas> AdicionarAlternativa(Alternativas alternativas);
		Task<Alternativas> AtualizarAlternativa(Alternativas alternativas, int alternativaId);
		Task<bool> ApagarAlternativa(int alternativaId);
	}
}
