using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }

        public string StudenrtName { get; set; } = null!;

        public string DeptName { get; set; } = null!;

        public string BloodGroup { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string? Cgpa { get; set; }

        public int DeptId { get; set; }
    }
}
