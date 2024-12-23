using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Models;

namespace StudentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentContext _context;

    public StudentsController(StudentContext context)
    {
        _context = context;
    }

    // POST: api/Students
        [HttpPost]
    public async Task<IActionResult> AddStudent([FromBody] Student student)
    {
        // Validar campos requeridos
        if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.Rut) ||
            string.IsNullOrEmpty(student.Email) || student.EnrollmentDate == default)
        {
            return BadRequest(new { Message = "Todos los campos son obligatorios." });
        }

        // Validar formato de RUT chileno
        if (!IsValidRut(student.Rut))
        {
            return BadRequest(new { Message = "El RUT ingresado no es válido." });
        }

        // Guardar en la base de datos
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        // Retornar el estudiante con ID asignado
        return Ok(student);
    }

    // GET: api/Students
    [HttpGet]
    public async Task<IActionResult> GetStudents()
    {
        // Obtener la lista de estudiantes desde la base de datos
        var students = await _context.Students.ToListAsync();

        // Verificar si hay estudiantes registrados
        if (students == null || !students.Any())
        {
            return NotFound(new { Message = "No se encontraron estudiantes registrados." });
        }

        return Ok(students);
    }

    private bool IsValidRut(string rut)
    {
        rut = rut.ToUpper().Trim();
        if (!System.Text.RegularExpressions.Regex.IsMatch(rut, @"^\d{7,8}[K0-9]$"))
        {
            return false;
        }

        var dv = rut[^1];
        var number = rut[..^1];
        int sum = 0, factor = 2;

        for (int i = number.Length - 1; i >= 0; i--)
        {
            sum += (number[i] - '0') * factor;
            factor = factor == 7 ? 2 : factor + 1;
        }

        var calculatedDv = 11 - (sum % 11);
        var expectedDv = calculatedDv == 11 ? '0' : (calculatedDv == 10 ? 'K' : calculatedDv.ToString()[0]);

        return dv == expectedDv;
    }
}
