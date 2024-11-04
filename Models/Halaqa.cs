namespace InstitutionManagmentSystem.Models;

public class Halaqa
{
    public int Id { get; set; }      
    public string Name { get; set; }  
    public  int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public List<Student>? Students { get; set; }
}
