using MyMinimalApi.Models;

namespace MyMinimalApi.Interfaces;
public interface IPeopleService
{
    string Create(Person person);
    List<Person> GetAll();
}

public class PeopleService : IPeopleService
{
    public string Create(Person person)
    {
        return $"Created {person.FirstName} {person.LastName}";
    }


    public List<Person> GetAll()
    {
        return new List<Person>
        {
            new Person { FirstName = "Amin", LastName = "Espinoza", Email = "amin.espinoza@me.com" },
            new Person { FirstName = "Marce", LastName = "Martinez", Email = "marce.martineza@me.com" },
            new Person { FirstName = "Miranda", LastName = "Espinoza", Email = "miranda.espinoza@me.com" },
            new Person { FirstName = "Felipe", LastName = "Bello", Email = "felipe.bello@me.com" }
        };
    }

    public Person CreatePeopleList(Person person)
    {
        return person;
    }
}