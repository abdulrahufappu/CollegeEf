using CollegeApi.ModelDtos;
using CollegeEf.Data;
using CollegeEf.Models;
using CollegeApi.ModelDtos;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeApi.ServiceInterfaces;

namespace CollegeEf.Services
{
    public class StudentServices : IStudentService
    {
        private readonly CollegeEfContext _collegeEf;
        public StudentServices(CollegeEfContext context)
        {
            _collegeEf = context;
        }

        public async Task<IEnumerable<StudentsDto>> GetAllStudents()
        {
            if (_collegeEf.Students != null)
            {
                var student = await _collegeEf.Students.ProjectToType<StudentsDto>().ToListAsync();
                return student;
            }
            throw new NotImplementedException();
        }
        public async Task<StudentsDto> GetStudents(int id)
        {
            if (_collegeEf.Students != null)
            {
                var stud = await _collegeEf.Students.ProjectToType<StudentsDto>().FirstAsync(s => s.Id == id);
                return stud;
            }
            throw new NotImplementedException();
        }
        public async Task<StudentsDto> PostStudents(StudentsDto studentDto)
        {
            if (_collegeEf != null)
            {

                var stud = studentDto.Adapt<Students>();
                _collegeEf.Students.Add(stud);
                await _collegeEf.SaveChangesAsync();
                return studentDto;
            }
            throw new NotImplementedException();
        }
        public async Task<StudentsDto> PutStudents(int id, StudentsDto students)
        {
            if (id == students.Id)
            {
                var stud = students.Adapt<Students>();
                _collegeEf.Entry(stud).State = EntityState.Modified;

                await _collegeEf.SaveChangesAsync();
                return students;

            }
            throw new NotImplementedException();
        }
        public async Task<StudentsDto> DeleteStudents(int id)
        {
            var students = await _collegeEf.Students.FindAsync(id);
            _collegeEf.Students.Remove(students);
             _collegeEf.SaveChangesAsync();
            return default;
        }
    }
}


    //public async Task<IEnumerable<StudentsDto>> GetStudents(int id)
    //{
    //    if (_collegeEf.Students != null)
    //    {
    //        var stud = await _collegeEf.Students.ProjectToType<StudentsDto>().First(i => i.Id == id);
    //        return stud;
    //    }
    //    throw new NotImplementedException();
    //}


