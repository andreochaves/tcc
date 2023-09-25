using Microsoft.AspNetCore.Mvc;
using QuestAdventureAPI.Models;
using QuestAdventureAPI.Repositories.Interfaces;

namespace QuestAdventureAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestaoController : ControllerBase
	{
		private readonly IQuestaoRepository _questaoRepository;

		public QuestaoController(IQuestaoRepository questaoRepository)
		{
			_questaoRepository = questaoRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<Questao>>> BuscarQuestoes()
		{
			List<Questao> questoes= await _questaoRepository.BuscarQuestoes();
			return Ok(questoes);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Questao>> BuscarPorId(int id)
		{
			Questao questao = await _questaoRepository.BuscarPorId(id);
			return Ok(questao);
		}

		[HttpGet("{materia}/{professor}")]
		public async Task<ActionResult<List<Questao>>> BuscarPorProfessorMateria(int materia, int professor)
		{
			List<Questao> questoes = await _questaoRepository.BuscarPorProfessorMateria(materia, professor);
			return Ok(questoes);
		}

		[HttpPost]
		public async Task<ActionResult<Questao>> Cadastrar([FromBody] Questao questao)
		{
			Questao questao1 = await _questaoRepository.AdicionarQuestao(questao);
			return Ok(questao1);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Questao>> AtualizarQuestao([FromBody] Questao questao, int id)
		{
			questao.Id = id;
			Questao questao1 = await _questaoRepository.AtualizarQuestao(questao, id);
			return Ok(questao1);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Questao>> ApagarQuestao(int id)
		{
			Boolean apagado = await _questaoRepository.ApagarQuestao(id);
			return Ok(apagado);
		}
	}
}
