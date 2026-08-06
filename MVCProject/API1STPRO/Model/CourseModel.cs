namespace API1STPRO.Model
{
    public class CourseModel
    {
        public int StudentId { get; set; }

        public string CourseName { get; set; } = null!;

        public string CourseId { get; set; } = null!;

        public string CourseTeacher { get; set; } = null!;

        public int DeptId { get; set; }
    }
}
