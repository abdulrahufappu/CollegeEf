using CollegeApi.ModelDtos;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApi.ServiceInterfaces
{
    public interface IFacultyService
    {
        public ActionResult<IEnumerable<FacultyDto>> GetAllFaculty();
        public Task<FacultyDto> GetFaculty(int id);
        public Task<FacultyDto> PostFaculty(FacultyDto faculty);
        public Task<FacultyDto> PutFaculty(int id, FacultyDto faculty);
        public Task<FacultyDto> DeleteFaculty(int id);
    }
}
