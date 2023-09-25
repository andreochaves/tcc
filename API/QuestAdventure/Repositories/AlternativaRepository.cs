using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventureAPI.Models;
using QuestAdventureAPI.Repositories.Interfaces;

namespace QuestAdventureAPI.Repositories
{
	public class AlternativaRepository : IAlternativaRepository
	{
		private readonly DataContext _dataContext;

		public AlternativaRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<Alternativas>> BuscarAlternativas()
		{
			return await _dataContext.Alternativa.ToListAsync();
		}

		public async Task<Alternativas> BuscarPorId(int alternativaId)
		{
			return await _dataContext.Alternativa.FirstOrDefaultAsync(x => x.Id == alternativaId);
		}

		public async Task<List<Alternativas>> BuscarPorQuestao(int questao)
		{
			var alternativa = await BuscarAlternativas();
			var alternativaLista = new List<Alternativas>();
			for(int i=0;i<alternativa.Count;i++)
			{
				if (alternativa[i].Questao==questao)
				{
					alternativaLista.Add(alternativa[i]);
				}
			}
			return alternativaLista;
		}

		public async Task<Alternativas> AdicionarAlternativa(Alternativas alternativas)
		{
			await _dataContext.Alternativa.AddAsync(alternativas);
			await _dataContext.SaveChangesAsync();
			return alternativas;
		}

		public async Task<Alternativas> AtualizarAlternativa(Alternativas alternativas, int alternativaId)
		{
			Alternativas alternativaPorId = await BuscarPorId(alternativaId);
			if (alternativaPorId == null)
			{
				throw new Exception("Alternativa não encontrada");
			}
			alternativaPorId.Alternativa = alternativas.Alternativa;
			alternativaPorId.Correto = alternativas.Correto;

			_dataContext.Alternativa.Update(alternativaPorId);
			await _dataContext.SaveChangesAsync();

			return alternativaPorId;
		}

		public async Task<bool> ApagarAlternativa(int alternativaId)
		{
			Alternativas alternativaPorId = await BuscarPorId(alternativaId);
			if (alternativaPorId == null)
			{
				throw new Exception("Alternativa não encontrada");
			}
			_dataContext.Alternativa.Remove(alternativaPorId);
			await _dataContext.SaveChangesAsync();

			return true;
		}
	}
}
