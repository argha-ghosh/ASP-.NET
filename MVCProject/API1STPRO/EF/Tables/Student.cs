using System;
using System.Collections.Generic;

namespace API1STPRO.EF.Tables;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudenrtName { get; set; } = null!;

    public string DeptName { get; set; } = null!;

    public string BloodGroup { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? Cgpa { get; set; }

    public int DeptId { get; set; }

    public virtual Department Dept { get; set; } = null!;
}
