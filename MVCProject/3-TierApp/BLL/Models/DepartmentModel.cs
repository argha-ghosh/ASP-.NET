using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class DepartmentModel
    {
        public int DeptId { get; set; }

        public string DeptName { get; set; } = null!;

        public string DeptLocation { get; set; } = null!;

        public string? DeptCourses { get; set; }

        public string? DeptStudents { get; set; }
    }
}
