using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeEf.Data;
using Mapster;
using CollegeApi.ModelDtos;
using CollegeApi.ServiceInterfaces;
using CollegeEf.Services;

namespace CollegeEf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultiesController : ControllerBase
    {
        private readonly CollegeEfContext _context;
        private readonly IFacultyService _facultyService;

        public FacultiesController(CollegeEfContext context, IFacultyService facultyService)
        {
            _context = context;
            _facultyService = facultyService;
        }

        // GET: api/Faculties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacultyDto>>> GetAllFaculty()
        {
            var fac = _facultyService.GetAllFaculty();
            return fac;
        }

        //public async Task<ActionResult<IEnumerable<Faculty>>> GetFaculty()
        //{
        //  if (_context.Faculty == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Faculty.ToListAsync();
        //}

        // GET: api/Faculties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyDto>> GetFaculty(int id)
        {
            var fac = await _facultyService.GetFaculty(id);
            return Ok(fac);
        }
        //public async Task<ActionResult<Faculty>> GetFaculty(int id)
        //{
        //  if (_context.Faculty == null)
        //  {
        //      return NotFound();
        //  }
        //    var faculty = await _context.Faculty.FindAsync(id);

        //    if (faculty == null)
        //    {
        //        return NotFound();
        //    }

        //    return faculty;
        //}

        // PUT: api/Faculties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<FacultyDto>> PutFaculty(int id, FacultyDto facultyDto)
        {
            //var stud = 
            return await _facultyService.PutFaculty(id, facultyDto);
        }
        //public async Task<IActionResult> PutFaculty(int id, Faculty faculty)
        //{
        //    if (id != faculty.FacultyId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(faculty).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FacultyExists(id))
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

        // POST: api/Faculties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacultyDto>> PostFaculty(FacultyDto facultyDto)
        {
            var fac = await _facultyService.PostFaculty(facultyDto);
            return CreatedAtAction("GetAllFaculty", new { id = fac.FacultyId }, fac);
        }
        //public async Task<ActionResult<Faculty>> PostFaculty(Faculty faculty)
        //{
        //  if (_context.Faculty == null)
        //  {
        //      return Problem("Entity set 'CollegeEfContext.Faculty'  is null.");
        //  }
        //    _context.Faculty.Add(faculty);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFaculty", new { id = faculty.FacultyId }, faculty);
        //}

        // DELETE: api/Faculties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaculty(int id)
        {
            var fac = await _facultyService.DeleteFaculty(id);
            return Ok(fac);
            //if (_context.Faculty == null)
            //{
            //    return NotFound();
            //}
            //var faculty = await _context.Faculty.FindAsync(id);
            //if (faculty == null)
            //{
            //    return NotFound();
            //}

            //_context.Faculty.Remove(faculty);
            //await _context.SaveChangesAsync();

            //return Ok("Successfully Deleted");
        }

        private bool FacultyExists(int id)
        {
            return (_context.Faculty?.Any(e => e.FacultyId == id)).GetValueOrDefault();
        }
    }
}
