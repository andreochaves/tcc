using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestAdventureAPI.Models;
using QuestAdventureAPI.Repositories.Interfaces;

namespace QuestAdventureAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AlternativaController : ControllerBase
	{
		private readonly IAlternativaRepository _alternativaRepository;

		public AlternativaController(IAlternativaRepository alternativaRepository)
		{
			_alternativaRepository = alternativaRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<Alternativas>>> BuscarAlternativas()
		{
			List<Alternativas> alternativas = await _alternativaRepository.BuscarAlternativas();
			return Ok(alternativas);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Alternativas>> BuscarPorId(int id)
		{
			Alternativas alternativas = await _alternativaRepository.BuscarPorId(id);
			return Ok(alternativas);
		}

		[HttpGet("Alternativa/{questao}")]
		public async Task<ActionResult<List<Alternativas>>> BuscarPorQuestao(int questao)
		{
			List<Alternativas> alternativas = await _alternativaRepository.BuscarPorQuestao(questao);
			return Ok(alternativas);
		}

		[HttpPost]
		public async Task<ActionResult<Alternativas>> Cadastrar([FromBody] Alternativas alternativas)
		{
			Alternativas alternativa = await _alternativaRepository.AdicionarAlternativa(alternativas);
			return Ok(alternativa);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Alternativas>> AtualizarAlternativa([FromBody] Alternativas alternativas, int id)
		{
			alternativas.Id = id;
			Alternativas alternativas1 = await _alternativaRepository.AtualizarAlternativa(alternativas, id);
			return Ok(alternativas1);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Alternativas>> ApagarAlternativa(int id)
		{
			Boolean apagado = await _alternativaRepository.ApagarAlternativa(id);
			return Ok(apagado);
		}
	}
}
