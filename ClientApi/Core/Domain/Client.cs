using System.Text.Json.Serialization;

namespace Core.Domain;

public class Client
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Cpf { get; set; }
    public string PhoneNumber { get; set; }
    public Client() { }
    public Client(string name, string email, int age, string cpf, string phoneNumber)
    {
        Name = name;
        Email = email;
        Age = age;
        Cpf = cpf;
        PhoneNumber = phoneNumber;
    }
}
