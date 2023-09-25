using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using QuestAdventure.Models;
using QuestAdventure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuestAdventure.Controllers
{
	public class AdminController : Controller
	{
		QuestService service = new QuestService();
		private string PegarMateriaId()
		{
			string selecao = "";
			for (int i = 0; i < UserManager.selecaoMateria.Count; i++)
			{
				for (int j = 0; j < UserManager.materiaView.Count; j++)
				{
					if (UserManager.selecaoMateria[i] == UserManager.materiaView[j].Materia)
					{
						string virgula = (i < (UserManager.selecaoMateria.Count - 1)) ? "," : "";
						selecao += UserManager.materiaView[j].Id + virgula;
					}
				}
			}
			return selecao;
		}

		private string PegarMateriaIdEdicao()
		{
			string selecao = "";
			for (int i = 0; i < UserManager.selecaoMateriaEdicao.Count; i++)
			{
				for (int j = 0; j < UserManager.materiaView.Count; j++)
				{
					if (UserManager.selecaoMateriaEdicao[i] == UserManager.materiaView[j].Materia)
					{
						string virgula = (i < (UserManager.selecaoMateriaEdicao.Count - 1)) ? "," : "";
						selecao += UserManager.materiaView[j].Id + virgula;
					}
				}
			}
			return selecao;
		}

		//Redirecionamentos
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult CadastroProfessor()
		{
			return View();
		}

		public IActionResult CadastroMateria()
		{
			return View();
		}
	
		public IActionResult CadastroMateriaEdicao()
		{
			return View();
		}

		public IActionResult TelaAdmin()
		{
			return View();
		}

		public async Task<ActionResult<Usuario>> Entrar(string email, string senha)
		{
			var loginAdmin = new Usuario()
			{
				Email = email.ToLower(),
				Senha = senha.ToLower(),
			};

			string login = $"?email={email}&password={senha}";

			var result = await service.PostResponse("Admin", login.ToLower(), loginAdmin);

			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("TelaAdmin");
			}
			else
			{
				ModelState.AddModelError("", "Email ou Senha Inválidos!");
			}

			return View("Index");
		}

		//Ações da Matéria
		public async Task<ActionResult<Materias>> CadastrarMateria(string materia)
		{
			Materias materias = new Materias()
			{
				Materia = materia
			};
			string registro = "";
			var result = await service.PostResponse("Materia", registro, materias);

			if (result.IsSuccessStatusCode)
			{
				UserManager.selecaoMateria.Add(materia);
				UserManager.materiaView.Add(materias);
				return RedirectToAction("CadastroMateria");
			}
			else
			{
				ModelState.AddModelError("", "Erro ao cadastrar a matéria");
			}
			return View("CadastroMateria");
		}

		public async Task<IActionResult> VisualizarMateria()
		{
			List<Materias> materias = new List<Materias>();

			var getData = await service.GetResponse("Materia");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				materias = JsonConvert.DeserializeObject<List<Materias>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma matéria encontrada!");
			}

			ViewData.Model = materias;
			return View();
		}

		public async Task<IActionResult> EditMateria(int id)
		{
			List<Materias> materias = new List<Materias>();
			
			var getData = await service.GetResponse("Materia");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				materias = JsonConvert.DeserializeObject<List<Materias>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma matéria encontrada!");
			}
			UserManager.materiaID = id;
			var mat = materias.Where(m => m.Id == id).FirstOrDefault();
			return View(mat);
		}

		public async Task<IActionResult> EditarMateria(string materia)
		{
			var mat = new Materias()
			{
				Materia = materia
			};

			var result = await service.PutResponse("Materia/", UserManager.materiaID, mat);

			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("VisualizarMateria");
			}
			else
			{
				ModelState.AddModelError("", "Erro ao cadastrar a matéria");
			}
			return View("VisualizarMateria");
		}

		public async Task<ActionResult<Materias>> CadastrarMateriaEdicao(string materia)
		{
			Materias materias = new Materias()
			{
				Materia = materia
			};

			var result = await service.PostResponse("Materia", materia, materias);

			if (result.IsSuccessStatusCode)
			{
				UserManager.selecaoMateriaEdicao.Add(materia);
				UserManager.materiaView.Add(materias);
				return RedirectToAction("CadastroMateriaEdicao");
			}
			else
			{
				ModelState.AddModelError("", "Erro ao cadastrar a matéria");
			}
			return View("CadastroMateriaEdicao");
		}

		public async Task<IActionResult> DeleteMateria(int id)
		{
			//Listar Professores
			List<Professor> professors = new List<Professor>();
			string novaMateria = "";
			var getData = await service.GetResponse("Professor");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				professors = JsonConvert.DeserializeObject<List<Professor>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhum professor encontrado!");
			}

			foreach (var professor in professors)
			{
				var listProf = professor.Materia.Split(",").ToList();
				for (int i = 0; i < listProf.Count; i++)
				{
					if (listProf[i] != id.ToString())
					{
						string virgula = (i < (listProf.Count - 1)) ? "," : "";
						novaMateria += listProf[i] + virgula;
					}
				}
				var professorEditado = new Professor()
				{
					Nome = professor.Nome,
					Materia = novaMateria,
					Email = professor.Email,
					Senha = professor.Senha,
				};

				var result = await service.PutResponse("Professor/", professor.Id, professorEditado);
				novaMateria = string.Empty;
			}

			//Deletar Materia do Professor

			var resultDelete = await service.DeleteResponse("Materia/", id.ToString());

			if (resultDelete.IsSuccessStatusCode)
			{
				return RedirectToAction("VisualizarMateria");
			}
			else
			{
				ModelState.AddModelError("", "Erro ao deletar a matéria");
			}

			return View("VisualizarMateria");
		}

		//Ações para Cadastro e Visualização do Professor
		public async Task<IActionResult> DisciplinaProfessor(string nome, string email, string senha)
		{
			UserManager.nome = nome;
			UserManager.email = email;
			UserManager.senha = senha;
			UserManager.materias.Clear();
			UserManager.selecaoMateria.Clear();
			UserManager.materiaView.Clear();
			List<Materias> list = new List<Materias>();

			var getData = await service.GetResponse("Materia");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				list = JsonConvert.DeserializeObject<List<Materias>>(results);
				UserManager.materiaView.AddRange(list);
				foreach (var materia in list)
					UserManager.materias.Add(materia.Materia);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma matéria encontrada!");
			}

			ViewData.Model = list;

			return View();
		}

		public async Task<IActionResult> VoltaCadastroProfessor()
		{
			UserManager.materiaView.Clear();
			List<Materias> list = new List<Materias>();

			var getData = await service.GetResponse("Materia");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				list = JsonConvert.DeserializeObject<List<Materias>>(results);
				UserManager.materiaView.AddRange(list);
			}
			return View("DisciplinaProfessor");
		}

		public async Task<IActionResult> VisualizarDisciplinaProfessor(int id)
		{
			Professor professor = new Professor();
			List<Materias> materias = new List<Materias>();
			UserManager.verMateriasProfessor.Clear();

			var getData = await service.GetResponse("Professor/" + id.ToString());
			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				professor = JsonConvert.DeserializeObject<Professor>(results);

				var getData2 = await service.GetResponse("Materia");

				if (getData2.IsSuccessStatusCode)
				{
					string results2 = getData2.Content.ReadAsStringAsync().Result;
					materias = JsonConvert.DeserializeObject<List<Materias>>(results2);

					foreach (var materiaId in professor.Materia.Split(","))
					{
						for (int i = 0; i < materias.Count; i++)
						{
							if (materiaId == materias[i].Id.ToString())
							{
								UserManager.verMateriasProfessor.Add(materias[i]);
							}
						}
					}
				}
			}
			else
			{
				Console.WriteLine("ERROR!!");
			}
			ViewData.Model = materias;
			return View();
		}

		public async Task<IActionResult> VisualizarProfessor()
		{
			List<Professor> professors = new List<Professor>();

			var getData = await service.GetResponse("Professor");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				professors = JsonConvert.DeserializeObject<List<Professor>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhum professor encontrado!");
			}
			ViewData.Model = professors;
			return View();
		}

		public IActionResult SelecionarMateria(string materia)
		{
			if (!string.IsNullOrEmpty(materia))
			{
				UserManager.selecaoMateria.Add(materia);
				for (int i = 0; i < UserManager.materias.Count; i++)
				{
					if (UserManager.materias[i] == materia)
					{
						UserManager.materias.Remove(UserManager.materias[i]);
					}
				}
			}
			return View("DisciplinaProfessor");
		}

		public IActionResult DeletarSelecao(string materia)
		{
			if (materia != null)
			{
				UserManager.materias.Add(materia);
				for (int i = 0; i < UserManager.selecaoMateria.Count; i++)
				{
					if (UserManager.selecaoMateria[i] == materia)
					{
						UserManager.selecaoMateria.Remove(UserManager.selecaoMateria[i]);
					}
				}
			}
			return View("DisciplinaProfessor");
		}

		public async Task<ActionResult<Professor>> CadastrarProfessor()
		{
			Professor novoProfessor = new Professor()
			{
				Nome = UserManager.nome,
				Materia = PegarMateriaId(),
				Email = UserManager.email,
				Senha = UserManager.senha,
			};

			string registro = $"?nome={novoProfessor.Nome}&materia={novoProfessor.Materia}&email={novoProfessor.Email}&senha={novoProfessor.Senha}";
			var result = await service.PostResponse("Professor", registro, novoProfessor);

			if (result.IsSuccessStatusCode)
			{
				UserManager.materias.Clear();
				return RedirectToAction("VisualizarProfessor");
			}
			else
			{
				ModelState.AddModelError("", "Todos os dados devem ser preenchidos!");
			}
			return View("CadastroProfessor");

		}

		//Alterações do Professor
		public async Task<IActionResult> EditProfessor(int id)
		{
			List<Materias> materias = new List<Materias>();
			List<Professor> professor = new List<Professor>();
			UserManager.materiasEdicao.Clear();
			UserManager.selecaoMateriaEdicao.Clear();

			//Selecionar Professor
			var getData = await service.GetResponse("Professor");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				professor = JsonConvert.DeserializeObject<List<Professor>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhum professor encontrado!");
			}

			//Selecionar Materia
			var getDataPM = await service.GetResponse("Materia");

			if (getDataPM.IsSuccessStatusCode)
			{
				string results = getDataPM.Content.ReadAsStringAsync().Result;
				materias = JsonConvert.DeserializeObject<List<Materias>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma matéria encontrada!");
			}

			//Selecionar dados do Professor
			UserManager.professorID = id;
			var prof = professor.Where(m => m.Id == id).FirstOrDefault();
			foreach (var materia in prof.Materia.Split(","))
			{
				for (int i = 0; i < materias.Count; i++)
				{
					if (materia == materias[i].Id.ToString())
					{
						UserManager.selecaoMateriaEdicao.Add(materias[i].Materia);
					}
				}
			}
			for (int i = 0; i < materias.Count; i++)
			{
				UserManager.materiasEdicao.Add(materias[i].Materia);
			}
			foreach (var selecao in UserManager.selecaoMateriaEdicao)
			{
				UserManager.materiasEdicao.Remove(selecao);
			}
			return View(prof);
		}

		public async Task<IActionResult> VoltaCadastroProfessorEdicao()
		{
			UserManager.materiaView.Clear();
			List<Materias> list = new List<Materias>();

			var getData = await service.GetResponse("Materia");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				list = JsonConvert.DeserializeObject<List<Materias>>(results);
				UserManager.materiaView.AddRange(list);
			}
			return View("EditDisciplinaProfessor");
		}

		public async Task<IActionResult> EditDisciplinaProfessor(string nome, string email, string senha)
		{
			UserManager.nome = nome;
			UserManager.email = email;
			UserManager.senha = senha;
			List<Materias> materias = new List<Materias>();

			var getData = await service.GetResponse("Materia");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				materias = JsonConvert.DeserializeObject<List<Materias>>(results);
				UserManager.materiaView.AddRange(materias);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma matéria encontrada!");
			}

			ViewData.Model = materias;
			return View();
		}

		public IActionResult SelecionarMateriaEdicao(string materia)
		{
			if (!string.IsNullOrEmpty(materia))
			{
				UserManager.selecaoMateriaEdicao.Add(materia);
				for (int i = 0; i < UserManager.materiasEdicao.Count; i++)
				{
					if (UserManager.materiasEdicao[i] == materia)
					{
						UserManager.materiasEdicao.Remove(UserManager.materiasEdicao[i]);
					}
				}
			}
			return View("EditDisciplinaProfessor");
		}

		public IActionResult DeletarSelecaoEdicao(string materia)
		{
			if (materia != null)
			{
				UserManager.materiasEdicao.Add(materia);
				for (int i = 0; i < UserManager.selecaoMateriaEdicao.Count; i++)
				{
					if (UserManager.selecaoMateriaEdicao[i] == materia)
					{
						UserManager.selecaoMateriaEdicao.Remove(UserManager.selecaoMateriaEdicao[i]);
					}
				}
			}
			return View("EditDisciplinaProfessor");
		}

		public async Task<IActionResult> EditarProfessor()
		{

			var professor = new Professor()
			{
				Nome = UserManager.nome,
				Materia = PegarMateriaIdEdicao(),
				Email = UserManager.email,
				Senha = UserManager.senha,
			};

			var result = await service.PutResponse("Professor/", UserManager.professorID, professor);

			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("VisualizarProfessor");
			}
			else
			{
				ModelState.AddModelError("", "Erro ao cadastrar a matéria");
			}
			return View("VisualizarProfessor");
		}

		public async Task<IActionResult> DeletarProfessor(int id)
		{

			var result = await service.DeleteResponse("Professor/", id.ToString());

			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("VisualizarProfessor");
			}
			return RedirectToAction("VisualizarProfessor");
		}
	}
}