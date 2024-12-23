namespace StudentAPI.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Rut { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
}
