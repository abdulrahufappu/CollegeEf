using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeEf.Data;
using CollegeEf.Models;
using CollegeApi.ModelDtos;
using CollegeApi.ServiceInterfaces;

namespace CollegeEf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly CollegeEfContext _context;
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(CollegeEfContext context, IDepartmentService departmentServices)
        {
            _context = context;
            _departmentService = departmentServices;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartment()
        {
            var dep = await _departmentService.GetAllDepartment();
            return Ok(dep);
        }
        //public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        //{
        //  if (_context.Departments == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Departments.ToListAsync();
        //}

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var dep = await _departmentService.GetDepartment(id);
            return Ok(dep);
        }
            //public async Task<ActionResult<Department>> GetDepartment(int id)
            //{
            //  if (_context.Departments == null)
            //  {
            //      return NotFound();
            //  }
            //    var department = await _context.Departments.FindAsync(id);

            //    if (department == null)
            //    {
            //        return NotFound();
            //    }

            //    return department;
            //}

            // PUT: api/Departments/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentDto>> PutDepartment(int id, DepartmentDto department)
        {
            var dep = await _departmentService.PutDepartment(id, department);
            return dep;
        }
        //public async Task<IActionResult> PutDepartment(int id, Department department)
        //{
        //    if (id != department.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(department).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> PostDepartment(DepartmentDto department)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'TestEFContext.Students'  is null.");
            }
            var dep = await _departmentService.PostDepartment(department);
            return CreatedAtAction("GetAllDepartment", new { id = dep.Id }, dep);
        }
        //public async Task<ActionResult<Department>> PostDepartment(Department department)
        //{
        //  if (_context.Departments == null)
        //  {
        //      return Problem("Entity set 'CollegeEfContext.Departments'  is null.");
        //  }
        //    _context.Departments.Add(department);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        //}

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return (_context.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
