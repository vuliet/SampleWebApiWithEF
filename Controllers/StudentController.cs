using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SampleWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;

        private static readonly List<Student> stu = new List<Student>
        {
            new Student
            {
                ID = 1,
                Name = "Thai Vu"
            },
            new Student
            {
                ID = 2,
                Name = "Thao Leu"
            },
            new Student
            {
                ID = 3,
                Name = "Thai Thao"
            }
        };

        public StudentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(stu);
            //return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var studenById = stu.Find(s => s.ID == id);
            if (studenById == null)
                return BadRequest("Student not found.");
            return Ok(studenById);

            //var studenById = await _context.Students.FindAsync(id);
            //if (studenById == null)
            //    return BadRequest("Student not found.");
            //return Ok(studenById);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<List<Student>>> AddStudent(Student student)
        {
            stu.Add(student);
            return Ok(stu);

            //_context.Students.Add(student);
            //await _context.SaveChangesAsync();
            //return Ok(await _context.Students.ToListAsync());
        }

        [HttpPut("Update")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(Student request)
        {
            var student = stu.Find(s => s.ID == request.ID);
            if (student == null)
                return BadRequest("Student not found.");
            student.ID = request.ID;
            student.Name = request.Name;
            return Ok(stu);

            //var student = await _context.Students.FindAsync(request.ID);
            //if (student == null)
            //    return BadRequest("Student not found.");
            //student.ID = request.ID;
            //student.Name = request.Name;
            //await _context.SaveChangesAsync();
            //return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var student = stu.Find(s => s.ID == id);
            if (student == null)
                return BadRequest("Student not found.");
            stu.Remove(student);
            return Ok(stu);

            //var student = await _context.Students.FindAsync(id);
            //if (student == null)
            //    return BadRequest("Student not found.");
            //_context.Students.Remove(student);
            //await _context.SaveChangesAsync();
            //return Ok(await _context.Students.ToListAsync());
        }
    }
}
