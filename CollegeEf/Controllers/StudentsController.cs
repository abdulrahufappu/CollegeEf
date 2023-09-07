using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeEf.Data;
using CollegeEf.Models;
using Mapster;
using CollegeApi.ModelDtos;
using CollegeApi.ServiceInterfaces;

namespace CollegeEf.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly CollegeEfContext _context;
        private readonly IStudentService _studentService;


        public StudentsController(CollegeEfContext context, IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentsDto>>> GetAllStudents()
        {
            var stud = await _studentService.GetAllStudents();
            return Ok(stud);
            //if (_context.Students == null)
            //{
            //    //var student = _context.Students.Adapt<List<StudentsDto>>();
            //    return Ok(_context.Students.ProjectToType<StudentsDto>().ToList());
            //    //return Ok(student);
            //}
        }
        //public IQueryable<StudentsDto> GetStudents()
        //{
        //    var student = from stud in _context.Students
        //                  select new StudentsDto
        //                  {
        //                      Id = stud.Id,
        //                      Name = stud.Name,
        //                      Address = stud.Address + " " + stud.City +" " + stud.PostalCode,
        //                  };
        //    return student;
        //}

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(int id)
        {
            var stud = await _studentService.GetStudents(id);
            return Ok(stud);

            //if (_context.Students == null)
            //{
            //    return NotFound();
            //}
            ////var students = _context.Students.Find(id).Adapt<StudentsDto>();
            //var students = _context.Students.ProjectToType<StudentsDto>().First(i=> i.Id==id);

            //if (students == null)
            //{
            //    return NotFound();
            //}

            //return Ok(students);
        }
        //public async Task<ActionResult<StudentsDto>> GetStudents(int id)
        //{
        //    //var students = await _context.Students.Include(s=>s.Course).Select(stud => new StudentsDto()
        //    //{ 
        //    //    Id=stud.Id,
        //    //    Name = stud.Name,
        //    //    Address = stud.Address + " " + stud.City + " " + stud.Region + " " + stud.Country + " " + stud.PostalCode,
        //    //    Guardian=stud.Fathername,
        //    //    Mobile= stud.Phone,
        //    //    CourseDtos= stud.Course.Select(c => new CourseDto[] {

        //    //        CourseId=c.CourseId,
        //    //        CourseName=c.CourseName
        //    //    })
        //    //}).SingleOrDefaultAsync(stud=> stud.Id == id);
        //    //var students = from m in _context.Students.Include(m => m.Course).Select(stud => new StudentsDto()
        //    //{
        //    //    Id = stud.Id,
        //    //    Name = stud.Name,
        //    //    Address = stud.Address + " " + stud.City + " " + stud.Region + " " + stud.Country + " " + stud.PostalCode,
        //    //    Guardian = stud.Fathername,
        //    //    Mobile = stud.Phone,
        //    //    CourseDtos = (ICollection<CourseDto>)stud.Course.Select(c => new CourseDto() { CourseId = c.CourseId, CourseName = c.CourseName, Duration = c.Duration }).Take(5)
        //    //});


        //    var studs = _context.Students.Select(student => new StudentsDto() {
        //        Id = student.Id,
        //        Name = student.Name,
        //        Address = student.Address + " " + student.City + " " + student.Region + " " + student.Country + " " + student.PostalCode,
        //        Guardian = student.Fathername,
        //        Mobile = student.Phone,
        //        CourseDtos = (ICollection<CourseDto>)student.Course.Select(c => new CourseDto() { CourseId = c.CourseId, CourseName = c.CourseName, Duration = c.Duration })
        //    }).First(i=> i.Id ==id);
        //    return Ok(studs);
        //}



        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<StudentsDto>> PutStudents(int id, StudentsDto students)
        {
            var stud = await _studentService.PutStudents(id,students);
            return Ok(stud);
        }
        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentsDto>> PostStudent(StudentsDto studentDto)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'TestEFContext.Students'  is null.");
            }
            var stud = await _studentService.PostStudents(studentDto);
            //_context.Students.Add(stud);
            //await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllStudents", new { id = stud.Id }, stud);
        }
        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudents(int id)
        {
            var stud = await _studentService.DeleteStudents(id);
            return Ok(stud);
            //if (_context.Students == null)
            //{
            //    return NotFound();
            //}
            //var students = await _context.Students.FindAsync(id);
            //if (students == null)
            //{
            //    return NotFound();
            //}

            //_context.Students.Remove(students);
            //await _context.SaveChangesAsync();

            //return NoContent();
        }

        private bool StudentsExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
