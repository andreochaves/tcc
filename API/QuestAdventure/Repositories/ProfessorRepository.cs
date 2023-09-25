using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly DataContext _context;

        public ProfessorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Professor>> BuscarProfessores()
        {
            return await _context.Professor.ToListAsync();
        }

        public async Task<Professor> BuscarProfessorPorId(int professorId)
        {
            return await _context.Professor.FirstOrDefaultAsync(x => x.Id == professorId);
        }

        public async Task<Professor> BuscarProfessorPorEmail(string professorEmail)
        {
            return await _context.Professor.FirstOrDefaultAsync(x => x.Email == professorEmail);
        }

        public async Task<Professor> AdicionarProfessor(Professor professor)
        {
            await _context.Professor.AddAsync(professor);
            await _context.SaveChangesAsync();

            return professor;
        }

        public async Task<bool> APagarProfessor(int id)
        {
            Professor professorPorId = await BuscarProfessorPorId(id);

            if (professorPorId == null)
            {
                throw new Exception("Professor não encntrado");
            }
            _context.Professor.Remove(professorPorId);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Professor> AtualizarProfessor(Professor professor, int id)
        {
            Professor professorPorId = await BuscarProfessorPorId(id);

            if (professorPorId == null)
            {
                throw new Exception("Usuário não encntrado");
            }
            professorPorId.Nome = professor.Nome;
            professorPorId.Email = professor.Email;
            professorPorId.Senha = professor.Senha;
            professorPorId.Materia = professor.Materia;

            _context.Professor.Update(professorPorId);
            await _context.SaveChangesAsync();

            return professorPorId;
        }

        public async Task<Professor> LoginProfessor(string email, string password)
        {
            Professor professor = await BuscarProfessorPorEmail(email);
            if (professor == null)
            {
                throw new ArgumentNullException("Email inválido!");
            }
            if (professor.Senha != password)
            {
                throw new Exception("Senha Inválida!");
            }
            return professor;
        }
    }
}
