using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeEf.Models
{
    public class Department
    {
        public int Id { get; set; } 
        public string DepartmentName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string HOD { get; set; } = string.Empty;
        public string StaffCount { get; set; } = string.Empty;
        public int CourseId { get; set; }

    }
}
