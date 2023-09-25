using QuestAdventureAPI.Models;

namespace QuestAdventureAPI.Repositories.Interfaces
{
	public interface IQuestaoRepository
	{
		Task<List<Questao>> BuscarQuestoes();
		Task<Questao> BuscarPorId(int questaoId);
		Task<List<Questao>> BuscarPorProfessorMateria(int materia, int professor);
		Task<Questao> AdicionarQuestao(Questao questao);
		Task<Questao> AtualizarQuestao(Questao questao,int questaoId);
		Task<bool> ApagarQuestao(int questaoId);
	}
}
