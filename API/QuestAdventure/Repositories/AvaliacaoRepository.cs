using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventureAPI.Repositories
{
	public class AvaliacaoRepository : IAvaliacaoRepository
	{
		private readonly DataContext _context;

		public AvaliacaoRepository(DataContext context)
		{
			_context = context;
		}
		public async Task<List<Avaliacao>> BuscarAvaliacao()
		{
			return await _context.Avaliacao.ToListAsync();
		}

		public async Task<Avaliacao> BuscarAvaliacaoPorId(int avaliacaoId)
		{
			return await _context.Avaliacao.FirstOrDefaultAsync(x => x.Id == avaliacaoId);
		}

		public async Task<List<Avaliacao>> BuscarAvaliacaoPorMateria(int materia, int professor)
		{
			var avaliacao = await BuscarAvaliacao();
			var avaliacaoLista = new List<Avaliacao>();
			for (int i = 0; i < avaliacao.Count; i++)
			{
				if (avaliacao[i].Materia == materia && avaliacao[i].Professor == professor)
				{
					avaliacaoLista.Add(avaliacao[i]);
				}
			}
			return avaliacaoLista;
		}

		public async Task<Avaliacao> AdicionarAvaliacao(Avaliacao avaliacao)
		{
			await _context.Avaliacao.AddAsync(avaliacao);
			await _context.SaveChangesAsync();

			return avaliacao;
		}

		public async Task<Avaliacao> AtualizarAvaliacao(Avaliacao avaliacao, int avaliacaoId)
		{
			Avaliacao avaliacaoPorId = await BuscarAvaliacaoPorId(avaliacaoId);

			if (avaliacaoPorId == null)
			{
				throw new Exception("Avaliacao não encntrada");
			}
			avaliacaoPorId.Nome = avaliacao.Nome;
			avaliacaoPorId.Tentativa = avaliacao.Tentativa;
			avaliacaoPorId.Professor = avaliacao.Professor;
			avaliacaoPorId.Materia = avaliacao.Materia;

			_context.Avaliacao.Update(avaliacaoPorId);
			await _context.SaveChangesAsync();

			return avaliacaoPorId;
		}

		public async Task<bool> ApagarAvaliacao(int avaliacaoId)
		{
			Avaliacao avaliacaoPorId = await BuscarAvaliacaoPorId(avaliacaoId);

			if (avaliacaoPorId == null)
			{
				throw new Exception("Avaliacao não encntrada");
			}

			_context.Avaliacao.Remove(avaliacaoPorId);
			await _context.SaveChangesAsync();

			return true;
		}
	}
}
