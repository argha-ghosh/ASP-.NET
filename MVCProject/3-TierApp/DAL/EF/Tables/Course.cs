using System;
using System.Collections.Generic;

namespace DAL.EF.Tables;

public partial class Course
{
    public int StudentId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseId { get; set; } = null!;

    public string CourseTeacher { get; set; } = null!;

    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
