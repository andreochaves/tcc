using QuestAdventure.Models;

namespace QuestAdventure.Repositories.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<List<Avaliacao>> BuscarAvaliacao();
        Task<Avaliacao> BuscarAvaliacaoPorId(int avaliacaoId);
        Task<List<Avaliacao>> BuscarAvaliacaoPorMateria(int materia, int professor);
        Task<Avaliacao> AdicionarAvaliacao(Avaliacao avaliacao);
        Task<Avaliacao> AtualizarAvaliacao(Avaliacao avaliacao, int avaliacaoId);
        Task<bool> ApagarAvaliacao(int avaliacaoId);
    }
}
