using System.ComponentModel.DataAnnotations;

namespace MyMinimalApi.Models;
public class Person
{
    [Required, MinLength(3)]
    public string? FirstName { get; set; }

    [Required, MinLength(3)]
    public string? LastName { get; set; }

    [Required, DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
}