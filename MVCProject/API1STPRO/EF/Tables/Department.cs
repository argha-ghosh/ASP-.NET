using System;
using System.Collections.Generic;

namespace API1STPRO.EF.Tables;

public partial class Department
{
    //internal object DeptName;

    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public string DeptLocation { get; set; } = null!;
}
