using Microsoft.AspNetCore.Mvc;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> BuscarAluno()
        {
            List<Aluno> alunos = await _alunoRepository.BuscarAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> BuscarAlunoPorId(int id)
        {
            Aluno aluno = await _alunoRepository.BuscarAlunoPorId(id);
            return Ok(aluno);
        }

        [HttpGet("{materia}/{professor}")]
        public async Task<ActionResult<List<Aluno>>> BuscarAlunoPorMateria(int materia,int professor)
        {
            List<Aluno> aluno = await _alunoRepository.BuscarAlunoPorMateria(materia,professor);
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> Cadastrar([FromBody] Aluno aluno)
        {
            Aluno aluno1 = await _alunoRepository.AdicionarAluno(aluno);
            return Ok(aluno1);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aluno>> AtualizarAluno([FromBody] Aluno aluno, int id)
        {
            aluno.Id = id;
            Aluno aluno1 = await _alunoRepository.AtualizarAluno(aluno, id);
            return Ok(aluno1);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aluno>> ApagarAluno(int id)
        {
            Boolean apagado = await _alunoRepository.ApagarAluno(id);
            return Ok(apagado);
        }

        [HttpPost("{email}")]
        public async Task<ActionResult<Aluno>> Login(string email)
        {
            Aluno aluno = await _alunoRepository.LoginAluno(email);
            return Ok(aluno);
        }
    }
}
