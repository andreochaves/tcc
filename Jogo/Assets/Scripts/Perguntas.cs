using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.Purchasing.MiniJSON;
using Newtonsoft.Json;

public class Perguntas : MonoBehaviour
{
    Fase[] fase;
    Alternativas[] alternativas;
    Questao questao = new Questao();
    GameManager gm;
    public GameObject PainelPergunta;
    public GameObject Chao;
    Text PerguntaQuestao;
    Text PerguntaA;
    Text PerguntaB;
    Text PerguntaC;
    Text PerguntaD;
    Text PerguntaE;
    int fases;
    int idAvaliacao;
    int tentar;
    string url = "https://12ba-2804-e80-401-1f00-3871-f1b7-b998-bd76.ngrok-free.app";
    string urlApi = "/Quest/api/";
    //string urlAvaliacao = "/jogo/?aluno=1&avaliacao=3&tentativas=3";

    private void Start()
    {
        PerguntaQuestao = GameObject.Find("Quest").GetComponent<Text>();
        PerguntaA = GameObject.Find("A").GetComponent<Text>();
        PerguntaB = GameObject.Find("B").GetComponent<Text>();
        PerguntaC = GameObject.Find("C").GetComponent<Text>();
        PerguntaD = GameObject.Find("D").GetComponent<Text>();
        PerguntaE = GameObject.Find("E").GetComponent<Text>();

        GameObject.Find("AlternativaA").GetComponent<Button>().onClick.AddListener(() => VerificaBotao(0));
        GameObject.Find("AlternativaB").GetComponent<Button>().onClick.AddListener(() => VerificaBotao(1));
        GameObject.Find("AlternativaC").GetComponent<Button>().onClick.AddListener(() => VerificaBotao(2));
        GameObject.Find("AlternativaD").GetComponent<Button>().onClick.AddListener(() => VerificaBotao(3));
        GameObject.Find("AlternativaE").GetComponent<Button>().onClick.AddListener(() => VerificaBotao(4));
        GameObject.Find("Fechar").GetComponent<Button>().onClick.AddListener(VoltarAoJogo);

        fases = GameManager.gm.Fases;
        onDeepLinkActivated(Application.absoluteURL);
        //onDeepLinkActivated(urlAvaliacao);
        idAvaliacao = ManagerAluno.ma.GetIdAvaliacao();
        StartCoroutine(GetJsonFase());
    }

    private void onDeepLinkActivated(string url)
    {
        string sceneName = url.Split("?"[0])[1];
        string[] listScene = sceneName.Split("&"[0]);

        foreach (var corte in listScene)
        {
            string[] link = corte.Split("="[0]);
            for (int i = 0; i < link.Length; i++)
            {
                if (link[0] == "aluno")
                {
                    ManagerAluno.ma.SetId(int.Parse(link[1]));
                }
                else if (link[0] == "avaliacao")
                {
                    ManagerAluno.ma.SetIdAvaliacao(int.Parse(link[1]));
                }
                else
                {
                    tentar = int.Parse(link[1]);
                }
            }
        }
    }
    public void VerificaBotao(int botao)
    {
        var isCorrect = GameManager.alts[botao].Correto;
        if (isCorrect == true)
        {
            PainelPergunta.SetActive(false);
            Time.timeScale = 1;
            ManagerAluno.ma.SetTentativas(1);
            Pontuacao(ManagerAluno.ma.GetTentativas());
            ManagerAluno.ma.SetTentativas(-ManagerAluno.ma.GetTentativas());
        }
        else
        {
            // Chao.transform.parent = null;
            PainelPergunta.SetActive(false);
            Time.timeScale = 1;
            Chao.SetActive(isCorrect);
            ManagerAluno.ma.SetTentativas(1);
        }
    }
    void Pontuacao(int tentativa)
    {
        int pontMax = 100;
        int pontMin = pontMax / tentar;
        if (tentativa > tentar)
        {
            ManagerAluno.ma.SetPontuacao(0);
        }
        else if (tentativa == 1)
        {
            ManagerAluno.ma.SetPontuacao(pontMax);
        }
        else
        {
            int pontfim = pontMax - (pontMin * tentativa) - pontMin;
            ManagerAluno.ma.SetPontuacao(pontfim);
        }

    }

    public void VoltarAoJogo()
    {
        PainelPergunta.SetActive(false);
        Time.timeScale = 1;
    }

    IEnumerator GetJsonFase()
    {
        string urlFase = url + urlApi + "Fase/Avaliacao/" + idAvaliacao;
        UnityWebRequest www = UnityWebRequest.Get(urlFase);
        www.certificateHandler = new CertificateWhore();
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            List<Fase> estaFase = new List<Fase>();
            System.Random rnd = new System.Random();
            string jsonResult = www.downloadHandler.text;

            fase = JsonConvert.DeserializeObject<Fase[]>(jsonResult);
            foreach (var teste in fase)
            {
                string[] idQuestao = teste.Questao.Split(","[0]);
                if (idQuestao.Length > 1)
                {
                    int idq = rnd.Next(idQuestao.Length);
                    Fase novafase = new Fase
                    {
                        Id = teste.Id,
                        Avaliacao = teste.Avaliacao,
                        NumeroFase = teste.NumeroFase,
                        Questao = idQuestao[idq]
                    };
                    estaFase.Add(novafase);
                }
                else
                {
                    estaFase.Add(teste);
                }
            }

            foreach (var esta in estaFase)
            {
                if (fases == esta.NumeroFase)
                {
                    StartCoroutine(GetJsonQuestao(esta.Questao));
                }
            }

        }
    }

    IEnumerator GetJsonQuestao(string idQuestao)
    {
        string urlQuestao = url + urlApi + "Questao/" + idQuestao;
        UnityWebRequest www = UnityWebRequest.Get(urlQuestao);
        www.certificateHandler = new CertificateWhore();
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string jsonResult = www.downloadHandler.text;
            Questao questao = JsonConvert.DeserializeObject<Questao>(jsonResult);

            PerguntaQuestao.text = questao.Pergunta;
            StartCoroutine(GetJsonAlternativa(questao.Id.ToString()));
        }
    }

    IEnumerator GetJsonAlternativa(string idQuestao)
    {
        string urlAlternativa = url + urlApi + "Alternativa/Alternativa/" + idQuestao;
        UnityWebRequest www = UnityWebRequest.Get(urlAlternativa);
        www.certificateHandler = new CertificateWhore();
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string jsonResult = www.downloadHandler.text;
            Alternativas[] alternativas = JsonConvert.DeserializeObject<Alternativas[]>(jsonResult);

            PerguntaA.text = alternativas[0].Alternativa;
            PerguntaB.text = alternativas[1].Alternativa;
            PerguntaC.text = alternativas[2].Alternativa;
            PerguntaD.text = alternativas[3].Alternativa;
            PerguntaE.text = alternativas[4].Alternativa;

            GameManager.alts = alternativas;
        }
    }
}

public class CertificateWhore : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}
