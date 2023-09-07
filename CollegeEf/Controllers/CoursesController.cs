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
    public class CoursesController : ControllerBase
    {
        private readonly CollegeEfContext _context;
        private readonly ICourseService _courseService;

        public CoursesController(CollegeEfContext context, ICourseService courseService)
        {
            _context = context;
            _courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAllCourses()
        {
            var course = await _courseService.GetAllCourses();
            return Ok(course);
            //public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
            //{
            //  if (_context.Courses == null)
            //  {
            //      return NotFound();
            //  }
            //    return await _context.Courses.ToListAsync();
            //}
        }
        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetCourse(id);
            return Ok(course);
        }
        //public async Task<ActionResult<Course>> GetCourse(int id)
        //{
        //  if (_context.Courses == null)
        //  {
        //      return NotFound();
        //  }
        //    var course = await _context.Courses.FindAsync(id);

        //    if (course == null)
        //    {
        //        return NotFound();
        //    }

        //    return course;
        //}

        //// PUT: api/Courses/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CourseDto>> PutCourse(int id, CourseDto course)
        {
            //var stud = 
            return await _courseService.PutCourse(id, course);
        }
        //public async Task<IActionResult> PutCourse(int id, Course course)
        //{
        //    if (id != course.CourseId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(course).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CourseExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Courses
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CourseDto>> PostCourse(CourseDto course)
        {
            var cour = await _courseService.PostCourse(course);
            return Ok(cour);
            //return CreatedAtAction("GetAllCourse", new { id = courseDto.CourseId }, cour);
        }
        //{
        //  if (_context.Courses == null)
        //  {
        //      return Problem("Entity set 'CollegeEfContext.Courses'  is null.");
        //  }
        //    _context.Courses.Add(course);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        //}

        //// DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool CourseExists(int id)
        //{
        //    return (_context.Courses?.Any(e => e.CourseId == id)).GetValueOrDefault();
        //}
    }
}
