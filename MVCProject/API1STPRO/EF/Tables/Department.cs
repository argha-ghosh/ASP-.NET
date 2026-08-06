using System;
using System.Collections.Generic;

namespace API1STPRO.EF.Tables;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public string DeptLocation { get; set; } = null!;

    public string? DeptCourses { get; set; }

    public string? DeptStudents { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
