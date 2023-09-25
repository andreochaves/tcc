using Microsoft.EntityFrameworkCore;
using QuestAdventure.Models;
using QuestAdventureAPI.Models;

namespace QuestAdventure.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<Admin> UsuarioMaster { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Materias> Materia { get; set; }
        public DbSet<Questao> Questao { get; set; }
        public DbSet<Alternativas> Alternativa { get; set; }
        public DbSet<Avaliacao> Avaliacao { get; set;}
        public DbSet<Fase> Fase { get; set; }
        public DbSet<Pontuacao> Pontuacao { get; set; }
    }
}
