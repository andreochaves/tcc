using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using QuestAdventure.Models;
using QuestAdventure.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestAdventure.Controllers
{
    public class ProfessorAvaliacaoController : Controller
    {
        QuestService service = new QuestService();

        public string PegarQuestaoId()
        {
            string selecao = "";
            for (int i = 0; i < UserManager.faseQuestoes.Count; i++)
            {
                for (int j = 0; j < UserManager.questoes2.Count; j++)
                {
                    if (UserManager.faseQuestoes[i] == UserManager.questoes2[j].Pergunta)
                    {
                        string virgula = (i < (UserManager.faseQuestoes.Count - 1)) ? "," : "";
                        selecao += UserManager.questoes2[j].Id + virgula;
                    }
                }
            }
            return selecao;
        }
        private async Task<List<Questao>> MostrarQuestao()
        {
            string busca = $"Questao/{UserManager.materiaID}/{UserManager.professorID}";
            var getData = await service.GetResponse(busca);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                UserManager.questoes2 = JsonConvert.DeserializeObject<List<Questao>>(results);
                UserManager.questoes = JsonConvert.DeserializeObject<List<Questao>>(results);
            }
            else
            {
                ModelState.AddModelError("", "Nenhuma Avaliação encntrada!");
            }

            ViewData.Model = UserManager.questoes;
            return UserManager.questoes;
        }

        public IActionResult TelaAvaliacao()
        {
            Materias nomeMateria = new Materias();
            string materia = UserManager._materia;
            nomeMateria.Materia = materia;
            ViewData.Model = nomeMateria;
            return View();
        }

        public IActionResult MontarAvaliacaoTitulo()
        {
            return View();
        }

        public IActionResult MontaAvaliacao()
        {
            return View();
        }

        public async Task<ActionResult> AvaliacaoMontada()
        {
            List<Questao> questaos = new List<Questao>();
            string busca = $"Questao/{UserManager.materiaID}/{UserManager.professorID}";
            var getData2 = await service.GetResponse(busca);

            if (getData2.IsSuccessStatusCode)
            {
                string results2 = getData2.Content.ReadAsStringAsync().Result;
                questaos = JsonConvert.DeserializeObject<List<Questao>>(results2);
                foreach (var fase in UserManager.fases)
                {
                    foreach (var quest in fase.Questao.Split(','))
                    {
                        for (int i = 0; i < questaos.Count; i++)
                        {
                            if (quest == questaos[i].Id.ToString())
                            {
                                UserManager.verQuestoes.Add(questaos[i]);
                            }
                        }
                    }
                }
            }
            return View();
        }

        public async Task<ActionResult> MontarAvaliacao(string nome, int tentativa)
        {
            Avaliacao novaAvaliacao = new Avaliacao()
            {
                Materia = UserManager.materiaID,
                Professor = UserManager.professorID,
                Nome = nome,
                Tentativa = tentativa,
            };

            string regisrto = "";

            var getData = await service.PostResponse("Avaliacao", regisrto, novaAvaliacao);

            if (getData.IsSuccessStatusCode)
            {
                await MostrarQuestao();
                UserManager.avaliacaoNome = nome;
                UserManager.avaliacaoTentativa = tentativa;
                return RedirectToAction("MontaAvaliacao");
            }
            else
            {
                ModelState.AddModelError("", "Erro ao Cadastrar a Avaliação!");
            }
            return View("MontarAvaliacaoTitulo");
        }

        public async Task<ActionResult> VerAvaliacoes()
        {
            List<Avaliacao> listaAvaliacoes = new List<Avaliacao>();
            string verAvaliacao = $"Avaliacao/{UserManager.materiaID}/{UserManager.professorID}";

            var getData = await service.GetResponse(verAvaliacao);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                listaAvaliacoes = JsonConvert.DeserializeObject<List<Avaliacao>>(results);
            }
            else
            {
                ModelState.AddModelError("", "Nenhuma Avaliação encntrada!");
            }

            ViewData.Model = listaAvaliacoes;
            return View();
        }

        public async Task<ActionResult> VerQuestoes(int id)
        {
            UserManager.verQuestoes.Clear();
            List<Fase> fase = new List<Fase>();
            List<Questao> questaos = new List<Questao>();
            string verFase = $"Fase/Avaliacao/{id}";

            var getData = await service.GetResponse(verFase);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                fase = JsonConvert.DeserializeObject<List<Fase>>(results);

                string busca = $"Questao/{UserManager.materiaID}/{UserManager.professorID}";
                var getData2 = await service.GetResponse(busca);

                if (getData2.IsSuccessStatusCode)
                {
                    string results2 = getData2.Content.ReadAsStringAsync().Result;
                    questaos = JsonConvert.DeserializeObject<List<Questao>>(results2);
                    foreach (var fase1 in fase)
                    {
                        foreach (var quest in fase1.Questao.Split(','))
                        {
                            for (int i = 0; i < questaos.Count; i++)
                            {
                                if (quest == questaos[i].Id.ToString())
                                {
                                    UserManager.verQuestoes.Add(questaos[i]);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Nenhuma Avaliação encntrada!");
            }

            ViewData.Model = fase;
            return View();
        }

        public async Task<IActionResult> DeletarAvaliacao(int id)
        {
            List<Fase> fases = new List<Fase>();
            var getData = await service.GetResponse("Fase");
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                fases = JsonConvert.DeserializeObject<List<Fase>>(results);
                foreach (var fase in fases)
                {
                    if (fase.Avaliacao == id)
                    {
                        await DeletarFase(fase.Id);
                    }
                }
            }
            var result = await service.DeleteResponse("Avaliacao/", id.ToString());

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("VerAvaliacoes");
            }

            return RedirectToAction("VerAvaliacoes");
        }
        public async Task<IActionResult> DeletarFase(int id)
        {
            var result = await service.DeleteResponse("Fase/", id.ToString());

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("DeletarAvaliacao");
            }

            return RedirectToAction("DeletarAvaliacao");
        }

        public IActionResult SelecionarQuestao(Questao quesstao)
        {
            if (quesstao != null)
            {
                for (int i = 0; i < UserManager.questoes.Count; i++)
                {
                    if (UserManager.questoes[i].Pergunta == quesstao.Pergunta)
                    {
                        UserManager.faseQuestoes.Add(quesstao.Pergunta);
                        UserManager.questoes.Remove(UserManager.questoes[i]);
                    }
                }
            }
            return View("MontaAvaliacao");
        }

        public async Task<IActionResult> ProximaFase()
        {
            List<Avaliacao> avaliacaos = new List<Avaliacao>();

            var getData = await service.GetResponse("Avaliacao");

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                avaliacaos = JsonConvert.DeserializeObject<List<Avaliacao>>(results);
                foreach (var avaliacao in avaliacaos)
                {
                    if (avaliacao.Nome == UserManager.avaliacaoNome)
                    {
                        UserManager.avaliacaoId = avaliacao.Id;
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Nenhuma Avaliação encntrada!");
            }
            UserManager.numeroFase = UserManager.fases.Count + 1;
            string questao = this.PegarQuestaoId();

            UserManager.fases.Add(new Fase
            {
                Avaliacao = UserManager.avaliacaoId,
                NumeroFase = UserManager.numeroFase,
                Questao = questao
            });
            UserManager.faseQuestoes.Clear();
            return View("MontaAvaliacao");
        }

        public async Task<IActionResult> VoltarAvaliacao()
        {
            List<Avaliacao> avaliacaos = new List<Avaliacao>();

            var getData = await service.GetResponse("Avaliacao");

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                avaliacaos = JsonConvert.DeserializeObject<List<Avaliacao>>(results);
                foreach (var avaliacao in avaliacaos)
                {
                    if (avaliacao.Nome == UserManager.avaliacaoNome)
                    {
                        await DeletarAvaliacao(avaliacao.Id);
                        UserManager.questoes.Clear();
                        UserManager.fases.Clear();
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Nenhuma Avaliação encntrada!");
            }
            return View("MontaAvaliacao");
        }

        public async Task<ActionResult<Fase>> CadastrarAvaliacao()
        {
            foreach (var fase in UserManager.fases)
            {
                Fase faseNova = new Fase()
                {
                    Avaliacao = fase.Avaliacao,
                    NumeroFase = fase.NumeroFase,
                    Questao = fase.Questao,
                };
                string registro = "";// $"avaliacao={fase.Avaliacao}&questao={fase.Questao}";
                var result = await service.PostResponse("Fase", registro, faseNova);
            }
            UserManager.fases.Clear();

            return View("VerAvaliacoes");
        }


        public async Task<ActionResult> VerNotas(int id, string avaliacao)
        {
            List<Pontuacao> listaPontuacoes = new List<Pontuacao>();
            List<PontuacaoNomes> listaPontuacoesNomes = new List<PontuacaoNomes>();
            Aluno aluno = new Aluno();
            string nomeAluno = "";
            string verPontuacao = $"Pontuacao/Avaliacao/{id}";
            var getData = await service.GetResponse(verPontuacao);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                listaPontuacoes = JsonConvert.DeserializeObject<List<Pontuacao>>(results);

                foreach (var pontuacao in listaPontuacoes)
                {
                    var getData2 = await service.GetResponse($"aluno/{pontuacao.Aluno}");
                    if (getData2.IsSuccessStatusCode)
                    {
                        string results2 = getData2.Content.ReadAsStringAsync().Result;
                        aluno = JsonConvert.DeserializeObject<Aluno>(results2);

                        listaPontuacoesNomes.Add(new PontuacaoNomes
                        {
                            Aluno = aluno.Nome,
                            Avaliacao = avaliacao,
                            PontuacaoMaxima = pontuacao.PontuacaoMaxima,
                            PontoFase = pontuacao.PontoFase,
                        });
                    }
                }

            }
            else
            {
                Console.WriteLine("ERROR!!");
            }

            ViewData.Model = listaPontuacoesNomes;
            return View();
        }

        public async Task<ActionResult> VerNotasAvaliacao()
        {
            List<Avaliacao> listaAvaliacoes = new List<Avaliacao>();
            string verAvaliacao = $"Avaliacao/{UserManager.materiaID}/{UserManager.professorID}";

            var getData = await service.GetResponse(verAvaliacao);

            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                listaAvaliacoes = JsonConvert.DeserializeObject<List<Avaliacao>>(results);
            }
            else
            {
                ModelState.AddModelError("", "Nenhuma Avaliação encntrada!");
            }

            ViewData.Model = listaAvaliacoes;
            return View();
        }

    }
}
