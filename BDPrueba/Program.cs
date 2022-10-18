using Microsoft.EntityFrameworkCore;
using BDPrueba.DataAccess;

var builder = WebApplication.CreateBuilder(args);


//SECCION DE DEFINICION PARA LA CONEXION SQL---------------------------------------

const string sqlConection = "conexion";

var conexionString = builder.Configuration.GetConnectionString(sqlConection);

builder.Services.AddDbContext<PruebaContext>(options => options.UseSqlServer(conexionString));

//SECCION DE DEFINICION PARA LA CONEXION SQL---------------------------------------


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
