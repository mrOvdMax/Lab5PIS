using Lab5PIS.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lab5PIS.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private static DataInitializer _data;
    private List<Student> _students;

    public StudentController()
    {
        _data = new DataInitializer();
        _students = _data.Data();
    }

    [HttpGet("{login}")]
    public IActionResult GetByLogin([FromRoute] string login)
    {
        if (_students == null || !_students.Any())
        {
            return NotFound("No students data available.");
        }

        var student = _students.FirstOrDefault(s => s.Login == login);
        if (student == null)
        {
            return NotFound($"Student with login '{login}' not found.");
        }

        return Ok(student);
    }
}