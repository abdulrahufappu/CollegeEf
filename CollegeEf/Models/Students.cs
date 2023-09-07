namespace CollegeEf.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string BloodGroup { get; set; } = string.Empty;
        public string Fathername { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public DateTime JoiningDate { get; set; } = DateTime.MinValue;

    }
}
