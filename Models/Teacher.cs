using InstitutionManagmentSystem.Interfaces;
using System.Text.Json.Serialization;

namespace InstitutionManagmentSystem.Models;

public class Teacher : IPerson
{

    public int Id { get; set; } 
    public string FistName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    [JsonIgnore]
    public Halaqa? Halaqa { get; set; }
}
