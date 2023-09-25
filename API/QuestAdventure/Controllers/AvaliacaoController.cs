using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestAdventure.Models;
using QuestAdventure.Repositories;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventureAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AvaliacaoController : ControllerBase
	{
		private readonly IAvaliacaoRepository _avaliacaoRepository;

		public AvaliacaoController(IAvaliacaoRepository avaliacaoRepository)
		{
			_avaliacaoRepository = avaliacaoRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<Avaliacao>>> BuscarAluno()
		{
			List<Avaliacao> avaliacaos = await _avaliacaoRepository.BuscarAvaliacao();
			return Ok(avaliacaos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Avaliacao>> BuscarAvaliacaoPorId(int id)
		{
			Avaliacao avaliacao = await _avaliacaoRepository.BuscarAvaliacaoPorId(id);
			return Ok(avaliacao);
		}

		[HttpGet("{materia}/{professor}")]
		public async Task<ActionResult<List<Avaliacao>>> BuscarAvaliacaoPorMateria(int materia, int professor)
		{
			List<Avaliacao> avaliacao = await _avaliacaoRepository.BuscarAvaliacaoPorMateria(materia, professor);
			return Ok(avaliacao);
		}

		[HttpPost]
		public async Task<ActionResult<Avaliacao>> Cadastrar([FromBody] Avaliacao avaliacao)
		{
			Avaliacao avaliacao1 = await _avaliacaoRepository.AdicionarAvaliacao(avaliacao);
			return Ok(avaliacao1);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Avaliacao>> AtualizarAvaliacao([FromBody] Avaliacao avaliacao, int id)
		{
			avaliacao.Id = id;
			Avaliacao avaliacao1 = await _avaliacaoRepository.AtualizarAvaliacao(avaliacao, id);
			return Ok(avaliacao1);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Avaliacao>> ApagarAvaliacao(int id)
		{
			Boolean apagado = await _avaliacaoRepository.ApagarAvaliacao(id);
			return Ok(apagado);
		}
	}
}
