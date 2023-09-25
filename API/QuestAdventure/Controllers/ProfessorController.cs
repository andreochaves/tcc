using Microsoft.AspNetCore.Mvc;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _professorRepository;

        public ProfessorController(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Professor>>> BuscarProfessor()
        {
            List<Professor> professores = await _professorRepository.BuscarProfessores();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> BuscarProfessorPorId(int id)
        {
            Professor professor = await _professorRepository.BuscarProfessorPorId(id);
            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<Professor>> Cadastrar([FromBody] Professor professor)
        {
            Professor professor1 = await _professorRepository.AdicionarProfessor(professor);
            return Ok(professor1);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Professor>> AtualizarProfessor([FromBody] Professor professor, int id)
        {
            professor.Id = id;
            Professor professor1 = await _professorRepository.AtualizarProfessor(professor, id);
            return Ok(professor1);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Professor>> ApagarProfessor(int id)
        {
            Boolean apagado = await _professorRepository.APagarProfessor(id);
            return Ok(apagado);
        }

        [HttpPost("{email}")]
        public async Task<ActionResult<Professor>> Login(string email, string password)
        {
            Professor professor = await _professorRepository.LoginProfessor(email, password);
            return Ok(professor);
        }

    }
}
