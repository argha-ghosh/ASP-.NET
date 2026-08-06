namespace API1STPRO.Model
{
    public class DepartmentStudentModel: DepartmentModel
    {
        public List<StudentModel> Students { get; set; } = new List<StudentModel>();
    }
}
