using Microsoft.AspNetCore.Mvc;
using QuestAdventureAPI.Models;
using QuestAdventureAPI.Repositories;
using QuestAdventureAPI.Repositories.Interfaces;

namespace QuestAdventureAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PontuacaoController : ControllerBase
	{
		private readonly IPontuacaoRepository _pontuacaoRepository;

		public PontuacaoController(IPontuacaoRepository pontuacaoRepository)
		{
            _pontuacaoRepository = pontuacaoRepository;
		}

		[HttpGet]
		public async Task<ActionResult<List<Pontuacao>>> BuscarPontuacoes()
		{
			List<Pontuacao> questoes= await _pontuacaoRepository.BuscarPontuacoes();
			return Ok(questoes);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Pontuacao>> BuscarPorId(int id)
		{
            Pontuacao questao = await _pontuacaoRepository.BuscarPorId(id);
			return Ok(questao);
		}

		[HttpGet("Avaliacao/{avaliacao}")]
		public async Task<ActionResult<List<Pontuacao>>> BuscarPorAvaliacao(int avaliacao)
		{
			List<Pontuacao> questoes = await _pontuacaoRepository.BuscarPorAvaliacao(avaliacao);
			return Ok(questoes);
		}

		[HttpPost]
		public async Task<ActionResult<Pontuacao>> Cadastrar([FromBody] Pontuacao questao)
		{
			Pontuacao questao1 = await _pontuacaoRepository.AdicionarPontuacao(questao);
			return Ok(questao1);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<Pontuacao>> AtualizarPontuacao([FromBody] Pontuacao questao)
		{
			//Questao questao1 = await _pontuacaoRepository.AtualizarPontuacao(questao);
			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Pontuacao>> ApagarPontuacao(int id)
		{
			Boolean apagado = await _pontuacaoRepository.ApagarPontuacao(id);
			return Ok(apagado);
		}
	}
}
