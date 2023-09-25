using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;
using QuestAdventureAPI.Models;

namespace QuestAdventureAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FaseController : ControllerBase
	{
		private readonly IFaseRepository _faseRepository;

		public FaseController(IFaseRepository faseRepository)
		{
			_faseRepository = faseRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<Fase>>> BuscarFase()
		{
			List<Fase> fases = await _faseRepository.BuscarFase();
			return Ok(fases);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Fase>> BuscarFasePorId(int id)
		{
			Fase fase = await _faseRepository.BuscarFasePorId(id);
			return Ok(fase);
		}

		[HttpGet("Jogo/{id}")]
		public async Task<ActionResult<Fase>> BuscarFasePorIdJogo(int id)
		{
			Fase fase = await _faseRepository.BuscarFasePorIdJogo(id);
			return Ok(fase);
		}

		[HttpGet("Avaliacao/{avaliacao}")]
		public async Task<ActionResult<List<Fase>>> BuscarFasePorAvaliacao(int avaliacao)
		{
			List<Fase> fase = await _faseRepository.BuscarFasePorAvaliacao(avaliacao);
			return Ok(fase);
		}

		[HttpPost]
		public async Task<ActionResult<Fase>> Cadastrar([FromBody] Fase fase)
		{
			Fase faseNova = await _faseRepository.AdicionarFase(fase);
			return Ok(faseNova);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Fase>> AtualizarFase([FromBody] Fase fase, int id)
		{
			fase.Id = id;
			Fase faseNova = await _faseRepository.AtualizarFase(fase, id);
			return Ok(faseNova);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Fase>> ApagarFase(int id)
		{
			Boolean apagado = await _faseRepository.ApagarFase(id);
			return Ok(apagado);
		}
	}
}
