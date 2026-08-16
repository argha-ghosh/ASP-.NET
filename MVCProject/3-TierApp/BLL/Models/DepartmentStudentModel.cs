using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models
{
    public class DepartmentStudentModel : DepartmentModel
    {
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();

        //public List<StudentModel> Students { get; set; }
    }
}
