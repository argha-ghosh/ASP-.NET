namespace API1STPRO.Model
{
    public class DepartmentCourseModel: DepartmentModel
    {
        public List<CourseModel> Courses { get; set; } = new List<CourseModel>();
    }
}
