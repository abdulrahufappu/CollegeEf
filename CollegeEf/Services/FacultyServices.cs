using CollegeApi.ModelDtos;
using CollegeApi.ServiceInterfaces;
using CollegeEf.Data;
using CollegeEf.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeEf.Services
{
    public class FacultyServices : IFacultyService
    {
        private readonly CollegeEfContext _collegeEf;
        public FacultyServices(CollegeEfContext context)
        {
            _collegeEf = context;
        }

        public ActionResult<IEnumerable<FacultyDto>>GetAllFaculty()
        {
            if (_collegeEf.Faculty != null)
            {
                var faculty =  _collegeEf.Faculty.ProjectToType<FacultyDto>().ToList();
                return faculty;
            }
            throw new NotImplementedException();
        }
      
        public async Task<FacultyDto> GetFaculty(int id)
        {
            if (_collegeEf.Faculty != null)
            {
                var faculty = await _collegeEf.Faculty.ProjectToType<FacultyDto>().FirstAsync(s => s.FacultyId == id);
                return faculty;
            }
            throw new NotImplementedException();
        }

        public async Task<FacultyDto> PostFaculty(FacultyDto facultyDto)
        {
            if (_collegeEf != null)
            {

                var fac = facultyDto.Adapt<Faculty>();
                //if (fac == null)
                //{
                //    return null;
                //}
                _collegeEf.Faculty.Add(fac);
                await _collegeEf.SaveChangesAsync();
                return facultyDto;
            }
            throw new NotImplementedException();
        }
        
        public async Task<FacultyDto> PutFaculty(int id, FacultyDto faculty)
        {
            if (id == faculty.FacultyId)
            {
                var fac = faculty.Adapt<Faculty>();
                _collegeEf.Entry(fac).State = EntityState.Modified;

                await _collegeEf.SaveChangesAsync();
                return faculty;

            }
            throw new NotImplementedException();
        }

        public async Task<FacultyDto> DeleteFaculty(int id)
        {
            var fac = await _collegeEf.Faculty.FindAsync(id);
            _collegeEf.Faculty.Remove(fac);
            _collegeEf.SaveChangesAsync();
            return default;
        }




    }
}
