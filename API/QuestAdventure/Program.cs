using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Repositories;
using QuestAdventure.Repositories.Interfaces;
using QuestAdventureAPI.Repositories;
using QuestAdventureAPI.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    var mysqlconn = builder.Configuration.GetConnectionString("DefautConnection");
    options.UseMySql(mysqlconn, ServerVersion.AutoDetect(mysqlconn));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Ler os repositorios
builder.Services.AddScoped<IAdminRepository, AdminRepsitory>();
builder.Services.AddScoped<IProfessorRepository,ProfessorRepository>();
builder.Services.AddScoped<IMateriaRepository,MateriaRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<IQuestaoRepository, QuestaoRepository>();
builder.Services.AddScoped<IAlternativaRepository, AlternativaRepository>();
builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
builder.Services.AddScoped<IFaseRepository, FaseRepository>();
builder.Services.AddScoped<IPontuacaoRepository, PontuacaoRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
