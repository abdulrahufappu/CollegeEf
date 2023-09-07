using CollegeApi.ModelDtos;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApi.ServiceInterfaces
{
    public interface ICourseService
    {
        public Task<IEnumerable<CourseDto>> GetAllCourses();
        public Task<CourseDto> GetCourse(int id);
        public Task<CourseDto> PostCourse(CourseDto course);
        public Task<CourseDto> PutCourse(int id, CourseDto course);
    }
}
