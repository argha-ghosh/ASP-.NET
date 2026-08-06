using AutoMapper;

namespace API1STPRO.Model
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public string StudenrtName { get; set; } = null!;

        public string ?DeptName { get; set; } = null!;

        public string BloodGroup { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string? Cgpa { get; set; }
    }
}
