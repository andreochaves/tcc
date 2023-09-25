using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly DataContext _context;

        public MateriaRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Materias>> BuscarMaterias()
        {
            return await _context.Materia.ToListAsync();
        }

        public async Task<Materias> BuscarMateriasPorId(int materiasId)
        {
            return await _context.Materia.FirstOrDefaultAsync(x => x.Id == materiasId);
        }
        public async Task<Materias> AdicionarMateria(Materias materias)
        {
            await _context.Materia.AddAsync(materias);
            await _context.SaveChangesAsync();

            return materias;
        }

        public async Task<bool> APagarMateria(int materiasId)
        {
            Materias materiaPorId = await BuscarMateriasPorId(materiasId);

            if (materiaPorId == null)
            {
                throw new Exception("Matéria não encntrada");
            }
            _context.Materia.Remove(materiaPorId);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Materias> AtualizarMateria(Materias materias, int materiasId)
        {
            Materias materiaPorId = await BuscarMateriasPorId(materiasId);

            if (materiaPorId == null)
            {
                throw new Exception("Matéria não encntrada");
            }
            materiaPorId.Materia = materias.Materia;

            _context.Materia.Update(materiaPorId);
            await _context.SaveChangesAsync();

            return materiaPorId;
        }

        
    }
}
