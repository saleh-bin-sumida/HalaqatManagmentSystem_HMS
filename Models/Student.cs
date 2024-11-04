using InstitutionManagmentSystem.Interfaces;

namespace InstitutionManagmentSystem.Models;

public class Student : IPerson
{
    public int Id { get; set; } 
    public string FistName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public int HalaqaId { get; set; } 
    public Halaqa? Halaqa { get; set; } 
}
