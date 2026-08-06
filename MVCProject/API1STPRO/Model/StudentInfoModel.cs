namespace API1STPRO.Model
{
    public class StudentInfoModel: StudentModel
    {
        public int DeptId { get; set; }
        public object DeptLocation { get; internal set; }
    }
}
