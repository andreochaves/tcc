using Microsoft.AspNetCore.Mvc;
using QuestAdventure.Models;
using System.Collections.Generic;

namespace QuestAdventure.Controllers
{
    public class UserManager
    {
        //Atualizado
        //Materia
        public static int materiaID = 0;
        public static List<Materias> verMateriasProfessor = new List<Materias>();
        public static List<Materias> materiaView = new List<Materias>();
        public static List<string> materias = new List<string>();
        public static List<string> selecaoMateria = new List<string>();
        public static List<string> materiasEdicao = new List<string>();
        public static List<string> selecaoMateriaEdicao = new List<string>();

        //Professor
        public static string nome = "";
        public static string email = "";
        public static string senha = "";
        public static int professorID = 0;
        public static string professorAluno = "";
        public static string materiaAluno = "";

        public static List<Materias> MateriaProfessor= new List<Materias>();
        public static List<Aluno> alunos = new List<Aluno>();
        public static string emailProfessor = "";
       
        //Aluno
        public static int alunoID = 0;
        public static string _nomeAluno = "";
        public static string emailAluno = "";
        public static List<Materias> MateriaAluno = new List<Materias>();

        public static int questaoID = 0;
		public static List<Alternativas> alternativas = new List<Alternativas>();
		public static List<Alternativas> alternativasEdit = new List<Alternativas>();

		public static int alternativaID = 0;



        //Geral
        public static string _materia = "";
        public static string avaliacaoNome = "";
		public static int avaliacaoId = 0;
		public static int avaliacaoTentativa = 0;
		public static int numeroFase = 0;

        //Questoes
        public static string questao = "";
        public static List<Questao> questoes = new List<Questao>();
        public static List<Questao> questoes2 = new List<Questao>();
        public static List<Questao> verQuestoes = new List<Questao>();
        public static List<Fase> fases = new List<Fase>();
		public static string faseQuestao = "";
        public static List<string> faseQuestoes = new List<string>();





	}
}
