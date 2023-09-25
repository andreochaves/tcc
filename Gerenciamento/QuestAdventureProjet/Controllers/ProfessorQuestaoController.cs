using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using QuestAdventure.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using QuestAdventure.Service;

namespace QuestAdventure.Controllers
{
	public class ProfessorQuestaoController : Controller
	{
		QuestService service = new QuestService();

		public IActionResult CadastroQuestao()
		{
			return View();
		}

		public IActionResult CadastroAlternativa()
		{
			return View();
		}

		public async Task<IActionResult> TelaQuestao()
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

		public async Task<ActionResult<Questao>> CadastrarQuestao(string pergunta)
		{
			List<Questao> questoesLista = new List<Questao>();

			Questao novaQuestao = new Questao()
			{
				Materia = UserManager.materiaID,
				Professor = UserManager.professorID,
				Pergunta = pergunta,
			};

			string registro = $"?Materia={UserManager.materiaID}&Professor={UserManager.professorID}&Pergunta={pergunta}";
			var result = await service.PostResponse("Questao", registro, novaQuestao);

			if (result.IsSuccessStatusCode)
			{
				UserManager.alternativas.Clear();
				UserManager.questao = pergunta;
				return RedirectToAction("CadastroAlternativa");
			}
			else
			{
				UserManager.alternativas.Clear();
				ModelState.AddModelError("", "Questão não cadastrada");
			}

			return View("CadastroQuestao");
		}

		public async Task<IActionResult> CadastrarAlternativa()
		{
			//Receber Questao
			foreach (var alternativa in UserManager.alternativas)
			{
				List<Questao> listaQuestoes = new List<Questao>();
				var getData = await service.GetResponse("Questao");

				if (getData.IsSuccessStatusCode)
				{
					string results = getData.Content.ReadAsStringAsync().Result;
					listaQuestoes = JsonConvert.DeserializeObject<List<Questao>>(results);
					foreach (var questa in listaQuestoes)
					{
						if (questa.Pergunta == UserManager.questao)
						{
							UserManager.questaoID = questa.Id;
						}
					}
				}
				else
				{
					ModelState.AddModelError("", "Nenhuma questão cadastrada!");
				}

				//Adicionar Alternativa
				Alternativas nova = new Alternativas()
				{
					Questao = UserManager.questaoID,
					Alternativa = alternativa.Alternativa,
					Correto = alternativa.Correto
				};
				string registro = $"?Questao={UserManager.questaoID}&Alternativa={alternativa.Alternativa}&Correto={alternativa.Correto}";
				var result = await service.PostResponse("Alternativa", registro, nova);

			}
			return RedirectToAction("ListaQuestao");
		}

		public async Task<IActionResult> ListaAlternativa(int id)
		{
			List<Alternativas> alternativas = new List<Alternativas>();
			var getData = await service.GetResponse("Alternativa/Alternativa/" + id.ToString());

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				alternativas = JsonConvert.DeserializeObject<List<Alternativas>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Questão sem alternativa!");
			}

			ViewData.Model = alternativas;
			return View();
		}

		public async Task<IActionResult> ListaQuestao()
		{
			List<Questao> listaQuestoes = new List<Questao>();
			string busca = $"Questao/{UserManager.materiaID}/{UserManager.professorID}";
			var getData = await service.GetResponse(busca);

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				listaQuestoes = JsonConvert.DeserializeObject<List<Questao>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma questão cadastrada!");
			}

			ViewData.Model = listaQuestoes;
			return View();
		}

		public IActionResult AdicionarAlternativa(string alternativa, bool correto)
		{
			Alternativas nova = new Alternativas()
			{
				Alternativa = alternativa,
				Correto = correto
			};

			int contador = 0;
			if (UserManager.alternativas.Count < 5)
			{
				UserManager.alternativas.Add(nova);
				foreach (var chec in UserManager.alternativas)
				{
					if (chec.Correto == true)
					{
						contador++;
						if (contador > 1)
						{
							DeleteAlternativa(chec.Alternativa);
							return View("CadastroAlternativa");
						}
					}
				}
			}

			return View("CadastroAlternativa");
		}

		public IActionResult DeleteAlternativa(string alternativa)
		{

			for (int i = 0; i < UserManager.alternativas.Count; i++)
			{
				if (UserManager.alternativas[i].Alternativa == alternativa)
				{
					UserManager.alternativas.Remove(UserManager.alternativas[i]);
				}
			}
			return View("CadastroAlternativa");
		}

		public async Task<IActionResult> DeletarQuestao(int id)
		{
			if (ModelState.IsValid)
			{
				List<Alternativas> alternativas = new List<Alternativas>();
				var getData = await service.GetResponse("Alternativa/Alternativa/" + id.ToString());

				if (getData.IsSuccessStatusCode)
				{
					string results = getData.Content.ReadAsStringAsync().Result;
					alternativas = JsonConvert.DeserializeObject<List<Alternativas>>(results);
					foreach (var alternativa in alternativas)
					{
						var result = await service.DeleteResponse("Alternativa/", alternativa.Id.ToString());
					}
				}
				else
				{
					ModelState.AddModelError("", "Questão sem alternativa!");
				}

				var result2 = await service.DeleteResponse("Questao/", id.ToString());

				if (result2.IsSuccessStatusCode)
				{
					return RedirectToAction("ListaQuestao");
				}
			}

			return RedirectToAction("ListaQuestao");
		}

		public async Task<IActionResult> EditQuestao(int id)
		{
			List<Questao> questoes = new List<Questao>();
			var getData = await service.GetResponse("Questao");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				questoes = JsonConvert.DeserializeObject<List<Questao>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma questão encontrado!");
			}
			UserManager.questaoID = id;
			var quest = questoes.Where(a => a.Id == id).FirstOrDefault();
			return View(quest);
		}

		public async Task<IActionResult> EditarQuestao(string pergunta)
		{
			var quest = new Questao()
			{
				Pergunta = pergunta,
			};


			var result = await service.PutResponse("Questao/", UserManager.questaoID, quest);

			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("EditAlternativa");
			}
			else
			{
				ModelState.AddModelError("", "Erro ao editar a questão");
			}
			return View("EditAlternativa");
		}

		public async Task<IActionResult> EditAlternativa()
		{
			List<Alternativas> alternativas = new List<Alternativas>();
			var getData = await service.GetResponse("Alternativa/Alternativa/" + UserManager.questaoID.ToString());

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				alternativas = JsonConvert.DeserializeObject<List<Alternativas>>(results);
			}
			else
			{
				ModelState.AddModelError("", "Nenhuma alternativa encontrada!");
			}
			UserManager.alternativasEdit = alternativas;

			return View();
		}

		public async Task<IActionResult> EditarAlternativa(string alternativa, bool correto)
		{
			var alt = new Alternativas()
			{
				Alternativa = alternativa,
				Correto = correto
			};

			var result = await service.PutResponse("Alternativa/", UserManager.alternativaID, alt);
			if (result.IsSuccessStatusCode)
			{
				return RedirectToAction("EditAlternativa");
			}
			else
			{
				ModelState.AddModelError("", "Questão não cadastrada");
			}
			return View("EditAlternativa");
		}

		public IActionResult EditAlternativaEdit(string alternativa)
		{
			var alt = UserManager.alternativasEdit.Where(x => x.Alternativa == alternativa).FirstOrDefault();
			UserManager.alternativaID = alt.Id;
			return View(alt);
		}

	}
}
