using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;
using QuestAdventureAPI.Models;
using System.Drawing.Drawing2D;

namespace QuestAdventureAPI.Repositories
{
	public class FaseRepository : IFaseRepository
	{
		private readonly DataContext _context;

		public FaseRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<List<Fase>> BuscarFase()
		{
			return await _context.Fase.ToListAsync();
		}

		public async Task<List<Fase>> BuscarFasePorAvaliacao(int avaliacao)
		{
			var fases = await BuscarFase();
			var faselista = new List<Fase>();
			for (int i = 0; i < fases.Count; i++)
			{
				if (fases[i].Avaliacao == avaliacao)
				{
					faselista.Add(fases[i]);
				}
			}
			return faselista;
		}

		public async Task<Fase> BuscarFasePorId(int faseId)
		{
			return await _context.Fase.FirstOrDefaultAsync(x => x.Id == faseId);
		}

		public async Task<Fase> BuscarFasePorIdJogo(int faseId)
		{
			return await _context.Fase.FirstOrDefaultAsync(x => x.Id == faseId);
		}

		public async Task<Fase> AdicionarFase(Fase fase)
		{
			await _context.Fase.AddAsync(fase);
			await _context.SaveChangesAsync();

			return fase;
		}
		public async Task<Fase> AtualizarFase(Fase fase, int faseId)
		{
			Fase fasePorId = await BuscarFasePorId(faseId);

			if (fasePorId == null)
			{
				throw new Exception("Fase não encntrada");
			}
			fasePorId.Questao = fase.Questao;

			_context.Fase.Update(fasePorId);
			await _context.SaveChangesAsync();

			return fasePorId;
		}

		public async Task<bool> ApagarFase(int faseId)
		{
			Fase fasePorId = await BuscarFasePorId(faseId);

			if (fasePorId == null)
			{
				throw new Exception("Fase não encntrada");
			}
			_context.Fase.Remove(fasePorId);
			await _context.SaveChangesAsync();
			
			return true;
		}
	}
}
