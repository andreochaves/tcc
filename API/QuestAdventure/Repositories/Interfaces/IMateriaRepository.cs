using QuestAdventure.Models;

namespace QuestAdventure.Repositories.Interfaces
{
    public interface IMateriaRepository
    {
        Task<List<Materias>> BuscarMaterias();
        Task<Materias> BuscarMateriasPorId(int materiasId);
        Task<Materias> AdicionarMateria(Materias materias);
        Task<Materias> AtualizarMateria(Materias materias, int materiasId);
        Task<bool> APagarMateria(int materiasId);
    }
}
