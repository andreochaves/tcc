using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using QuestAdventure.Models;
using QuestAdventure.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuestAdventure.Controllers
{
	public class ProfessorController : Controller
	{
		QuestService service = new QuestService();

		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> TelaProfessor()
		{
			Professor professor = new Professor();
			int id = 0;
			string _nome = "";
			List<Materias> materias = new List<Materias>();
			List<Professor> professorLista = new List<Professor>();
			UserManager.MateriaProfessor.Clear();
			
			var getData = await service.GetResponse("Professor");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				professorLista = JsonConvert.DeserializeObject<List<Professor>>(results);

				foreach (var x in professorLista)
				{
					if (x.Email.Contains(UserManager.emailProfessor))
					{
						id = x.Id;
						_nome = x.Nome;
						UserManager.professorID = id;
					}
				}
				var getData2 = await service.GetResponse("Professor/" + id.ToString());

				if (getData2.IsSuccessStatusCode)
				{
					string results2 = getData2.Content.ReadAsStringAsync().Result;
					professor = JsonConvert.DeserializeObject<Professor>(results2);
					professor.Nome = _nome.ToUpperInvariant();

					var getData3 = await service.GetResponse("Materia");

					if (getData3.IsSuccessStatusCode)
					{
						string results3 = getData3.Content.ReadAsStringAsync().Result;
						materias = JsonConvert.DeserializeObject<List<Materias>>(results3);

						foreach (var materiaId in professor.Materia.Split(","))
						{
							for (int i = 0; i < materias.Count; i++)
							{
								if (materiaId == materias[i].Id.ToString())
								{
									UserManager.MateriaProfessor.Add(materias[i]);
								}
							}
						}
					}
					else
					{
						ModelState.AddModelError("", "Nenhuma matéria encontrada!");
					}
				}
				else
				{
					ModelState.AddModelError("", "Nenhuma matéria cadastrada!");
				}

				ViewData.Model = professor;
			}
			return View();
		}

		public async Task<ActionResult> TelaMateria()
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

		public async Task<ActionResult<Professor>> Entrar(string email, string senha)
		{
			var loginProfessor = new Professor()
			{
				Email = email.ToLower(),
				Senha = senha.ToLower(),
			};
			string login = $"{email}?password={senha}";

			var result = await service.PostResponse("Professor/", login.ToLower(), loginProfessor);

			if (result.IsSuccessStatusCode)
			{
				UserManager.emailProfessor=loginProfessor.Email;
				return RedirectToAction("TelaProfessor");
			}
			else
			{
				ModelState.AddModelError("", "Email ou Senha Inválidos!");
			}
			return View("Index");
		}

		public IActionResult Selecionar(string materia, int id)
		{
			UserManager._materia = materia;
			UserManager.materiaID = id;
			return RedirectToAction("TelaMateria");
		}
	}
}