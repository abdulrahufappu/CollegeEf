using CollegeApi.ModelDtos;
using CollegeApi.ServiceInterfaces;
using CollegeEf.Data;
using CollegeEf.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CollegeEf.Services
{
    public class DepartmentServices : IDepartmentService
    {
        private readonly CollegeEfContext _collegeEf;
        public DepartmentServices(CollegeEfContext context)
        {
            _collegeEf = context;
        }
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartment()
        {
            if (_collegeEf.Departments != null)
            {
                var dep = await _collegeEf.Departments.ProjectToType<DepartmentDto>().ToListAsync();
                return dep;
            }
            throw new NotImplementedException();
        }

        public async Task<DepartmentDto> GetDepartment(int id)
        {
            if (_collegeEf.Departments != null)
            {
                var dep = await _collegeEf.Departments.ProjectToType<DepartmentDto>().FirstAsync(s => s.Id == id);
                return dep;
            }
            throw new NotImplementedException();
        }

        public async Task<DepartmentDto> PostDepartment(DepartmentDto department)
        {
            if (_collegeEf != null)
            {

                var dep = department.Adapt<Department>();
                _collegeEf.Departments.Add(dep);
                await _collegeEf.SaveChangesAsync();
                return department;
            }
            throw new NotImplementedException();
        }

        public async Task<DepartmentDto> PutDepartment(int id, DepartmentDto department)
        {
            if (id == department.Id)
            {
                var dep = department.Adapt<Department>();
                _collegeEf.Entry(dep).State = EntityState.Modified;
                await _collegeEf.SaveChangesAsync();
                return department;

            }
            throw new NotImplementedException();
        }
    }
}
