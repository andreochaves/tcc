using QuestAdventureAPI.Models;

namespace QuestAdventureAPI.Repositories.Interfaces
{
	public interface IPontuacaoRepository
    {
		Task<List<Pontuacao>> BuscarPontuacoes();
		Task<Pontuacao> BuscarPorId(int pontuacaoId);
		Task<List<Pontuacao>> BuscarPorAvaliacao(int avaliacao);
		Task<Pontuacao> AdicionarPontuacao(Pontuacao pontuacao);
		Task<Pontuacao> AtualizarPontuacao(Pontuacao pontuacao);
		Task<bool> ApagarPontuacao(int pontuacaoId);
	}
}
