using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using QuestAdventure.Models;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Json;
using Nancy;
using System.IO;
using QuestAdventure.Service;
using System.Collections.Generic;

namespace QuestAdventure.Controllers
{
    public class AlunoController : Controller
    {
        QuestService service = new QuestService();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult<Usuario>> Entrar(string email)
        {
            Aluno loginAluno = new Aluno()
            {
                Email = email.ToLower()
            };

            //string registro = 
            var result = await service.PostResponse("Aluno/", email.ToLower(), loginAluno);

            if (result.IsSuccessStatusCode)
            {
                string results2 = result.Content.ReadAsStringAsync().Result;
                UserManager.emailAluno = loginAluno.Email;
                return RedirectToAction("TelaAluno");
            }
            else
            {
                ModelState.AddModelError("", "Email não cadastrado!");
            }

            return View("Index");
        }

        public async Task<IActionResult> TelaAluno()
        {
            Aluno aluno = new Aluno();
            List<Aluno> listarAluno = new List<Aluno>();
            List<Materias> materias = new List<Materias>();

            var getData = await service.GetResponse("Aluno");

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                listarAluno = JsonConvert.DeserializeObject<List<Aluno>>(results);

                foreach (var x in listarAluno)
                {
                    if (x.Email.Contains(UserManager.emailAluno))
                    {
                        UserManager.alunoID = x.Id;
                        UserManager._nomeAluno = x.Nome;
                    }
                }

                var getData2 = await service.GetResponse("Aluno/" + UserManager.alunoID.ToString());
                if (getData2.IsSuccessStatusCode)
                {
                    string results2 = getData2.Content.ReadAsStringAsync().Result;
                    aluno = JsonConvert.DeserializeObject<Aluno>(results2);

                    var getData3 = await service.GetResponse("Materia");

                    if (getData3.IsSuccessStatusCode)
                    {
                        string results3 = getData3.Content.ReadAsStringAsync().Result;
                        materias = JsonConvert.DeserializeObject<List<Materias>>(results3);
                        //foreach (var materiaId in aluno.Materia.Split(","))
                        //{
                            for (int i = 0; i < materias.Count; i++)
                            {
                                if (aluno.Materia == materias[i].Id)
                                {
                                    UserManager.MateriaAluno.Add(materias[i]);
                                }
                            }
                        //}
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

            ViewData.Model = aluno;
            return View();
        }

        public IActionResult Selecionar(string materia, int id)
        {
            UserManager._materia = materia;
            UserManager.materiaID = id;
            return RedirectToAction("TelaAlunoMateria");
        }

        public async Task<IActionResult> TelaAlunoMateria()
        {
            List<Avaliacao> avaliacaos = new List<Avaliacao>();
            List<Avaliacao> avaliacoes = new List<Avaliacao>();
            var getData = await service.GetResponse("Avaliacao");

            if (getData.IsSuccessStatusCode)
            {
                string results3 = getData.Content.ReadAsStringAsync().Result;
                avaliacaos = JsonConvert.DeserializeObject<List<Avaliacao>>(results3);
                foreach (var mat in avaliacaos)
                {
                    if (mat.Materia == UserManager.materiaID)
                    {
                        avaliacoes.Add(mat);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Nenhuma matéria encontrada!");
            }
            ViewData.Model = avaliacoes;

            return View();
        }

        public IActionResult SelecionarAvaliacao(int id, string tent)
        {
            string linkJogo = "https://12ba-2804-e80-401-1f00-3871-f1b7-b998-bd76.ngrok-free.app/jogo/";
            string alunoId = "?aluno=";
            string avaliado = "&avaliacao=";
            string tentativa = "&tentativas=";
            linkJogo += alunoId + UserManager.alunoID + avaliado + id + tentativa + tent;

            return Redirect(linkJogo);
        }
    }
}
