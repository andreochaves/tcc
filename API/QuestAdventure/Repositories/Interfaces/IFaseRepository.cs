using QuestAdventure.Models;
using QuestAdventureAPI.Models;

namespace QuestAdventure.Repositories.Interfaces
{
    public interface IFaseRepository
    {
        Task<List<Fase>> BuscarFase();
        Task<Fase> BuscarFasePorId(int faseId);
        Task<Fase> BuscarFasePorIdJogo(int faseId);
        Task<List<Fase>> BuscarFasePorAvaliacao(int avaliacao);
        Task<Fase> AdicionarFase(Fase fase);
        Task<Fase> AtualizarFase(Fase fase, int faseId);
        Task<bool> ApagarFase(int faseId);
    }
}
