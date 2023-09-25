using Microsoft.AspNetCore.Mvc;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaRepository _materiaRepository;

        public MateriaController(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Materias>>> BuscarMaterias()
        {
            List<Materias> materias= await _materiaRepository.BuscarMaterias();
            return Ok(materias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> BuscarProfessorPorId(int id)
        {
            Materias materias= await _materiaRepository.BuscarMateriasPorId(id);
            return Ok(materias);
        }

        [HttpPost]
        public async Task<ActionResult<Materias>> Cadastrar([FromBody] Materias materias)
        {
            Materias materia = await _materiaRepository.AdicionarMateria(materias);
            return Ok(materia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Materias>> AtualizarMateria([FromBody] Materias materias, int id)
        {
            materias.Id = id;
            Materias materia = await _materiaRepository.AtualizarMateria(materias, id);
            return Ok(materia);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Materias>> ApagarProfessor(int id)
        {
            Boolean apagado = await _materiaRepository.APagarMateria(id);
            return Ok(apagado);
        }
    }
}