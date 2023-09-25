using QuestAdventure.Models;

namespace QuestAdventure.Repositories.Interfaces
{
    public interface IProfessorRepository
    {
        Task<List<Professor>> BuscarProfessores();
        Task<Professor> BuscarProfessorPorId(int professorId);
        Task<Professor> BuscarProfessorPorEmail(string professorEmail);
        Task<Professor> LoginProfessor(string email, string password);
        Task<Professor> AdicionarProfessor(Professor professor);
        Task<Professor> AtualizarProfessor(Professor professor, int id);
        Task<bool> APagarProfessor(int id);
    }
}
