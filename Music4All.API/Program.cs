using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;
using Music4All.API.Mapper;
using Music4All.Domain;
using Music4All.Infraestructure;
using Music4All.Infraestructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependecy injection
builder.Services.AddScoped<IEventDomain, EventDomain>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IMusicDomain, MusicDomain>();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IMusicianDomain, MusicianDomain>();
builder.Services.AddScoped<IMusicianRepository, MusicianRepository>();
builder.Services.AddScoped<IContractorDomain, ContractorDomain>();
builder.Services.AddScoped<IContractorRepository, ContractorRepository>();
builder.Services.AddScoped<IGuardianDomain, GuardianDomain>();
builder.Services.AddScoped<IGuardianRepository, GuardianRepository>();

//Conexion a MySQL 
var connectionString = builder.Configuration.GetConnectionString("music4allConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 30));

builder.Services.AddDbContext<Music4AllBDContext>(
    dbContextOptions => dbContextOptions.UseMySql(connectionString, serverVersion)
);

builder.Services.AddAutoMapper(
    typeof(ModelToResource),
    typeof(ResourceToModel)
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<Music4AllBDContext>())
{
    context.Database.EnsureCreated();
}

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