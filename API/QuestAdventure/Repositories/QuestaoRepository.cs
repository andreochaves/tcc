using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventureAPI.Models;
using QuestAdventureAPI.Repositories.Interfaces;

namespace QuestAdventureAPI.Repositories
{
	public class QuestaoRepository : IQuestaoRepository
	{
		private readonly DataContext _dataContext;

		public QuestaoRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task<List<Questao>> BuscarQuestoes()
		{
			return await _dataContext.Questao.ToListAsync();
		}

		public async Task<Questao> BuscarPorId(int questaoId)
		{
			return await _dataContext.Questao.FirstOrDefaultAsync(x => x.Id == questaoId);
		}

		public async Task<List<Questao>> BuscarPorProfessorMateria(int materia, int professor)
		{
			var questoes = await BuscarQuestoes();
			var questoesLista = new List<Questao>();
			for (int i=0;i<questoes.Count;i++)
			{
				if (questoes[i].Materia==materia && questoes[i].Professor == professor)
				{
					questoesLista.Add(questoes[i]);
				}
			}
			return questoesLista;
		}
		public async Task<Questao> AdicionarQuestao(Questao questao)
		{
			await _dataContext.Questao.AddAsync(questao);
			await _dataContext.SaveChangesAsync();
			return questao;
		}

		public async Task<Questao> AtualizarQuestao(Questao questao, int questaoId)
		{
			Questao questaoPorId = await BuscarPorId(questaoId);
			if (questaoPorId == null)
			{
				throw new Exception("Questão não encontrada");
			}
			questaoPorId.Pergunta = questao.Pergunta;

			_dataContext.Questao.Update(questaoPorId);
			await _dataContext.SaveChangesAsync();

			return questaoPorId;
		}

		public async Task<bool> ApagarQuestao(int questaoId)
		{
			Questao questaoPorId = await BuscarPorId(questaoId);
			if (questaoPorId == null)
			{
				throw new Exception("Questão não encontrada");
			}
			_dataContext.Questao.Remove(questaoPorId);
			await _dataContext.SaveChangesAsync();

			return true;
		}
	}
}
