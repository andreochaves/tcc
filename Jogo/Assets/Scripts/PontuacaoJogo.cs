using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class PontuacaoJogo : MonoBehaviour
{
    string url = "https://12ba-2804-e80-401-1f00-3871-f1b7-b998-bd76.ngrok-free.app/Quest/api/";
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Pontuacao nova = new Pontuacao()
            {
                Aluno = ManagerAluno.ma.GetId(),
                Avaliacao = ManagerAluno.ma.GetIdAvaliacao(),
                PontuacaoMaxima = ManagerAluno.ma.GetPontuacao(),
                PontoFase = ManagerAluno.ma.GetPontuacaoPorFase().ToString()
            };

            PostResponse("Pontuacao", "", nova);

            //StartCoroutine(IPontuacao());
        }
    }


    IEnumerator IPontuacao()
    {
        Pontuacao nova = new Pontuacao()
        {
            Aluno = 1,
            Avaliacao = 3,
            PontuacaoMaxima = 100,
            PontoFase = "100,0,0,0,0,0,0,0,0,0,0,0,0,0,0"
        };

        //var serializer = JsonUtility.ToJson(nova);
        // var json = serializer.Serialize(nova);
        // var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

        WWWForm form = new WWWForm();
        form.AddField("Aluno", nova.Aluno);//ManagerAluno.ma.GetId());
        form.AddField("Avaliacao", nova.Avaliacao);// ManagerAluno.ma.GetIdAvaliacao());
        form.AddField("PontuacaoMaxima", nova.PontuacaoMaxima);// ManagerAluno.ma.GetPontuacao());
        form.AddField("PontoFase", nova.PontoFase);//ManagerAluno.ma.GetPontuacaoPorFase().ToString());
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.certificateHandler = new CertificateWhore();
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                print(message: www.error);
            }

            else
            {
                print(message: "sucesso");
                Application.OpenURL("http://www.questadventure.somee.com/");
            }
        }
    }

    public async Task<HttpResponseMessage> PostResponse(string endpoint, string registro, Pontuacao obj)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new System.Uri(url + endpoint);
            //var serializer = new JavaScriptSerializer();
            var json = JsonUtility.ToJson(obj);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await client.PostAsync(registro.ToLower(), stringContent);
            return result;
        }
    }
}

internal class JavaScriptSerializer
{
    public JavaScriptSerializer()
    {
    }
}
// public class CertificateWhore : CertificateHandler
// {
//     protected override bool ValidateCertificate(byte[] certificateData)
//     {
//         return true;
//     }
// }
