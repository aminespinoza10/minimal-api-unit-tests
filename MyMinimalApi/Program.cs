
using MyMinimalApi.Interfaces;
using MyMinimalApi.Models;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IPeopleService, PeopleService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/people", (IPeopleService service, Person person) => 
    !MiniValidator.TryValidate(person, out var errors) 
        ? Results.ValidationProblem(errors) 
        : Results.Ok(service.Create(person)));

app.Run();

public partial class Program { }
