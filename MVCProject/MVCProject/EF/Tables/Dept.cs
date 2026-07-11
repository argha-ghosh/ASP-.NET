using System;
using System.Collections.Generic;

namespace MVCProject.EF.Tables;

public partial class Dept
{
    public int Deptd { get; set; }

    public string DeptName { get; set; } = null!;

    public string? Location { get; set; }
}
