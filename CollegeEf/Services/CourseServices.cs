using CollegeApi.ModelDtos;
using CollegeApi.ServiceInterfaces;
using CollegeEf.Data;
using CollegeEf.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeEf.Services
{
    public class CourseServices : ICourseService
    {
        private readonly CollegeEfContext _collegeEf;
        public CourseServices(CollegeEfContext context)
        {
            _collegeEf = context;
        }
        //Get all interface
        public async Task<IEnumerable<CourseDto>> GetAllCourses()
        {
            if (_collegeEf.Courses != null)
            {
                var course = await _collegeEf.Courses.ProjectToType<CourseDto>().ToListAsync();
                return course;
            }
            throw new NotImplementedException();
        }

        //Get by id interface
        public async Task<CourseDto> GetCourse(int id)
        {
            if (_collegeEf.Courses != null)
            {
                var cor = await _collegeEf.Courses.ProjectToType<CourseDto>().FirstAsync(s => s.CourseId == id);
                return cor;
            }
            throw new NotImplementedException();
        }

        public async Task<CourseDto> PutCourse(int id, CourseDto course)
        {
            if (id == course.CourseId)
            {
                var cour = course.Adapt<Course>();
                _collegeEf.Entry(cour).State = EntityState.Modified;
                await _collegeEf.SaveChangesAsync();
                return course;
            }
            throw new NotImplementedException();
        }
        public async Task<CourseDto> PostCourse(CourseDto course)
        {
            if (_collegeEf != null)
            {
                var cour = course.Adapt<Course>();
                _collegeEf.Courses.Add(cour);
                await _collegeEf.SaveChangesAsync();
                return course;
            }
            throw new NotImplementedException();
        }
    }
}
