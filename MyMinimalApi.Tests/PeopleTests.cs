using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace MyMinimalApi.Tests;
public class PeopleTests
{
    [Fact]
    public async Task PostPeople_ReturnsOk_WhenValid()
    {
        await using var application = new WebApplicationFactory<Program>();

        var client = application.CreateClient();
        var result = await client.PostAsJsonAsync("/people", new Person
        {
            FirstName = "Miranda",
            LastName = "Espinoza",
            Email = "miranda@espinoza.com"
        });
    
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        Assert.Equal("\"Created Miranda Espinoza\"", await result.Content.ReadAsStringAsync());
    }
  
    [Fact]
    public async Task CreatePersonValidatesObject()
    {
        await using var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();
        var result = await client.PostAsJsonAsync("/people", new Person
        {
            FirstName = "Miranda",
            LastName = "Espinoza"
        });
    }

    [Fact]
    public async Task GetPeople_ReturnsOk()
    {
        await using var application = new WebApplicationFactory<Program>();
        
        var client = application.CreateClient();
        var response = await client.GetAsync("/people");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task PostPeople_ReturnsValidationProblem_WhenInvalid()
    {
        await using var application = new WebApplicationFactory<Program>();
        var client = application.CreateClient();
        var person = new Person();

        var response = await client.PostAsJsonAsync("/people", person);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}

public class Person{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}