using CollegeApi.ModelDtos;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApi.ServiceInterfaces
{
    public interface IStudentService
    {
        public Task<IEnumerable<StudentsDto>> GetAllStudents();
        public Task<StudentsDto> GetStudents(int id);
        public Task<StudentsDto> PostStudents(StudentsDto students);
        public Task<StudentsDto> PutStudents(int id, StudentsDto students);
        public Task<StudentsDto> DeleteStudents(int id);
    }
}