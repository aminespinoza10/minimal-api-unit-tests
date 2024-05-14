using MyMinimalApi.Models;

namespace MyMinimalApi.Interfaces;
public interface IPeopleService
{
    string Create(Person person);
}

public class PeopleService : IPeopleService
{
    public string Create(Person person)
    {
        return $"Created {person.FirstName} {person.LastName}";
    }
}