using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuestAdventure.Models;
using QuestAdventure.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestAdventure.Controllers
{
	public class ProfessorAlunoController : Controller
	{
		QuestService service = new QuestService();

		public async Task<IActionResult> TelaAluno()
		{
			List<Materias> materias = new List<Materias>();
			Materias materia = new Materias();
			var getData = await service.GetResponse("Materia");

			if (getData.IsSuccessStatusCode)
			{
				string results3 = getData.Content.ReadAsStringAsync().Result;
				materias = JsonConvert.DeserializeObject<List<Materias>>(results3);
				foreach (var mat in materias)
				{
					if (mat.Id == UserManager.materiaID)
					{
						materia = mat;
					}
				}
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma matéria encontrada!");
			}
			ViewData.Model = materia;
			return View();
		}

		public async Task<ActionResult<Aluno>> CadastrarAluno()
		{
			foreach (var aluno in UserManager.alunos)
			{
				Aluno novoAluno = new Aluno()
				{
					Professor = aluno.Professor,
					Materia = aluno.Materia,
					Nome = aluno.Nome,
					Email = aluno.Email,
				};


				var registroAluno = $"?professor={aluno.Professor}&materia={aluno.Materia}&nome={aluno.Nome}&email={aluno.Email}";
				var result = await service.PostResponse("Aluno", registroAluno, novoAluno);
			}
			UserManager.alunos.Clear();
			return RedirectToAction("VerAluno");
		}


		public IActionResult CadastroAluno()
		{
			return View();
		}

		public async Task<IActionResult> VerAluno()
		{
			List<Aluno> listaAlunos = new List<Aluno>();
			string verAluno = $"Aluno/{UserManager.materiaID}/{UserManager.professorID}";
			var getData = await service.GetResponse(verAluno);

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhum aluno cadastrado!");
			}
			ViewData.Model = listaAlunos;

			return View();
		}

		public IActionResult AdicionarAluno(string nome, string email)
		{
			Aluno aluno = new Aluno()
			{
				Professor = UserManager.professorID,
				Materia = UserManager.materiaID,
				Nome = nome,
				Email = email,
			};
			UserManager.alunos.Add(aluno);
			return View("CadastroAluno");
		}

		public async Task<IActionResult> EditAluno(int id)
		{
			List<Aluno> alunos = new List<Aluno>();
			var getData = await service.GetResponse("Aluno");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				alunos = JsonConvert.DeserializeObject<List<Aluno>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhum aluno encontrado!");
			}
			UserManager.alunoID = id;
			var alu = alunos.Where(a => a.Id == id).FirstOrDefault();
			return View(alu);
		}

		public async Task<IActionResult> EditarAluno(string nome, string email)
		{
			var alu = new Aluno()
			{
				Professor = UserManager.professorID,
				Materia = UserManager.materiaID,
				Nome = nome,
				Email = email,
			};


			var result = await service.PutResponse("Aluno/", UserManager.alunoID, alu);

			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("VerAluno");
			}
			else
			{
				ModelState.AddModelError("", "Erro ao editar o aluno");
			}
			return View("VerAluno");
		}

		public IActionResult DeleteAluno(string aluno)
		{
			for (int i = 0; i < UserManager.alunos.Count; i++)
			{
				if (UserManager.alunos[i].Email == aluno)
				{
					UserManager.alunos.Remove(UserManager.alunos[i]);
				}
			}
			return View("CadastroAluno");
		}

		public async Task<IActionResult> DeletarAluno(int id)
		{
			var result = await service.DeleteResponse("Aluno/", id.ToString());

			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("VerAluno");
			}
			return RedirectToAction("VerAluno");
		}
	}
}
