using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext _context;

        public AlunoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> BuscarAlunos()
        {
            return await _context.Aluno.ToListAsync();
        }
        public async Task<Aluno> BuscarAlunoPorId(int alunoId)
        {
            return await _context.Aluno.FirstOrDefaultAsync(x => x.Id == alunoId);
        }

        public async Task<Aluno> BuscarAlunoPorEmail(string email)
        {
            return await _context.Aluno.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<Aluno>> BuscarAlunoPorMateria(int materia, int professor)
        {
            var alunos = await BuscarAlunos();
            var alunolista = new List<Aluno>();
            for(int i = 0; i < alunos.Count; i++)
            {
                if (alunos[i].Materia==materia && alunos[i].Professor == professor)
                {
                    alunolista.Add(alunos[i]);
                }
            }
            return alunolista;
        }

        public async Task<Aluno> AdicionarAluno(Aluno aluno)
        {
            await _context.Aluno.AddAsync(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task<Aluno> AtualizarAluno(Aluno aluno, int alunoId)
        {
            Aluno alunoPorId = await BuscarAlunoPorId(alunoId);

            if (alunoPorId == null)
            {
                throw new Exception("Aluno não encntrado");
            }
            alunoPorId.Nome = aluno.Nome;
            alunoPorId.Email = aluno.Email;
            alunoPorId.Professor = aluno.Professor;
            alunoPorId.Materia = aluno.Materia;

            _context.Aluno.Update(alunoPorId);
            await _context.SaveChangesAsync();

            return alunoPorId;
        }

        public async Task<bool> ApagarAluno(int alunoId)
        {
            Aluno alunoPorId = await BuscarAlunoPorId(alunoId);

            if (alunoPorId == null)
            {
                throw new Exception("Aluno não encntrado");
            }
            _context.Aluno.Remove(alunoPorId);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Aluno> LoginAluno(string email)
        {
            Aluno aluno = await BuscarAlunoPorEmail(email);
            if (aluno == null)
            {
                throw new ArgumentNullException("Email não cadastrado!");
            }
            return aluno;
        }
    }
}
