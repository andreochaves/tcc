using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerAluno : MonoBehaviour
{
    public static ManagerAluno ma;
    int idAlunoLogin;
    int idAvaliacao;
    int pontuacao;
    int tentativas = 0;
    string pontuacaoPorFase;
    List<int> pontoQuestao = new List<int>();

    public int GetId()
    {
        return idAlunoLogin;
    }

    public void SetId(int id)
    {
        idAlunoLogin = id;
    }

    public int GetIdAvaliacao()
    {
        return idAvaliacao;
    }

    public void SetIdAvaliacao(int id)
    {
        idAvaliacao = id;
    }

    public int GetPontuacao()
    {
        return pontuacao;
    }

    public string GetPontuacaoPorFase()
    {
        pontuacaoPorFase = "";
        for (int i = 0; i < pontoQuestao.Count; i++)
        {
            string virgula = (i < (pontoQuestao.Count - 1)) ? "," : "";
            pontuacaoPorFase += pontoQuestao[i].ToString() + virgula;
        }
        return pontuacaoPorFase;
    }

    public void SetPontuacao(int ponto)
    {
        pontuacao += ponto;
        pontoQuestao.Add(ponto);
    }
    
    public int GetTentativas()
    {
        return tentativas;
    }

    public void SetTentativas(int tentativa)
    {
        tentativas += tentativa;
    }

    void Awake()
    {
        if (ma == null)
        {
            ma = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (ma != this)
        {
            Destroy(gameObject);
        }
    }
}