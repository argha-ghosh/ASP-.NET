using API1STPRO.EF.Tables;
using API1STPRO.Model;
using System.Runtime.CompilerServices;
using AutoMapper;

namespace API1STPRO
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();
            CreateMap<Department, DepartmentStudentModel>().ReverseMap();
            CreateMap<Department, DepartmentCourseModel>().ReverseMap();
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<Student, StudentInfoModel>().
                ForMember(
                dest => dest.DeptLocation,
                src => src.MapFrom(s => s.Dept.DeptLocation)
                );
            CreateMap<Department, DepartmentInfoModel>().
                ForMember(
                dest => dest.CountOfStudents,
                src => src.MapFrom(s => s.Students.Count)
                ).
                ForMember(
                dest => dest.CountOfCourses,
                src => src.MapFrom(s => s.Courses.Count.ToString())
                );
        }
    }
}
