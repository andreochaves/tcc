using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventureAPI.Models;
using QuestAdventureAPI.Repositories.Interfaces;
using System.Drawing.Drawing2D;

namespace QuestAdventureAPI.Repositories
{
	public class PontuacaoRepository : IPontuacaoRepository
	{
		private readonly DataContext _dataContext;

		public PontuacaoRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<Pontuacao>> BuscarPontuacoes()
		{
			return await _dataContext.Pontuacao.ToListAsync();
		}

		public async Task<Pontuacao> BuscarPorId(int pontuacaoId)
		{
			return await _dataContext.Pontuacao.FirstOrDefaultAsync(x => x.Id == pontuacaoId);
		}

		public async Task<List<Pontuacao>> BuscarPorAvaliacao(int avaliacao)
		{
            var pontuacao = await BuscarPontuacoes();
            var pontuacaoLista = new List<Pontuacao>();
            for (int i = 0; i < pontuacao.Count; i++)
            {
                if (pontuacao[i].Avaliacao == avaliacao)
                {
                    pontuacaoLista.Add(pontuacao[i]);
                }
            }
            return pontuacaoLista;

        }
        public async Task<Pontuacao> AdicionarPontuacao(Pontuacao pontuacao)
		{
			await _dataContext.Pontuacao.AddAsync(pontuacao);
			await _dataContext.SaveChangesAsync();
			return pontuacao;
		}

		public async Task<Pontuacao> AtualizarPontuacao(Pontuacao pontuacao)
		{
			//Pontuacao pontuacaoPorId = await BuscarPorId(questaoId);
			//if (questaoPorId == null)
			//{
			//	throw new Exception("Questão não encontrada");
			//}
   //         pontuacaoPorId.Pergunta = pontuacao.Pergunta;

			//_dataContext.Questao.Update(pontuacaoPorId);
			//await _dataContext.SaveChangesAsync();

			return pontuacao;
		}

		public async Task<bool> ApagarPontuacao(int pontuacaoId)
		{
			Pontuacao pontuacaoPorId = await BuscarPorId(pontuacaoId);
			if (pontuacaoPorId == null)
			{
				throw new Exception("Pontuação não encontrada");
			}
			_dataContext.Pontuacao.Remove(pontuacaoPorId);
			await _dataContext.SaveChangesAsync();

			return true;
		}
	}
}
