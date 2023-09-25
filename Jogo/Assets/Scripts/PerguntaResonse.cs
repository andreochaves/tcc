using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Questao
{
    public int Id;
    public int Materia;
    public int Professor;
    public string Pergunta;
}

[Serializable]
public class Alternativas
{
    public int Id;
    public int Questao;
    public string Alternativa;
    public bool Correto;
}

[Serializable]
public class Fase
{
    public int Id;
    public int Avaliacao;
    public int NumeroFase;
    public string Questao;
}

[Serializable]
public class Pontuacao
{
    public int Id;
    public int Avaliacao;
    public int Aluno;
    public int PontuacaoMaxima;
    public string PontoFase;
}