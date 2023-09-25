using QuestAdventure.Models;

namespace QuestAdventure.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        Task<List<Aluno>> BuscarAlunos();
        Task<Aluno> BuscarAlunoPorId(int alunoId);
        Task<List<Aluno>> BuscarAlunoPorMateria(int materia, int professor);
        Task<Aluno> LoginAluno(string email);
        Task<Aluno> AdicionarAluno(Aluno aluno);
        Task<Aluno> AtualizarAluno(Aluno aluno, int alunoId);
        Task<bool> ApagarAluno(int alunoId);
    }
}
