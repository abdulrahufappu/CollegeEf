using CollegeApi.ModelDtos;

namespace CollegeApi.ServiceInterfaces
{
    public interface IDepartmentService
    {

        public Task<IEnumerable<DepartmentDto>> GetAllDepartment();
        public Task<DepartmentDto> GetDepartment(int id);
        public Task<DepartmentDto> PostDepartment(DepartmentDto department);
        public Task<DepartmentDto> PutDepartment(int id, DepartmentDto department);

    }
}
