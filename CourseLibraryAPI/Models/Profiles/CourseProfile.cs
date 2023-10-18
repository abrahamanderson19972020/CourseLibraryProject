using AutoMapper;
using CourseLibraryAPI.Models.DTOs;
using CourseLibraryAPI.Models.Entities;

namespace CourseLibraryAPI.Models.Profiles
{
    public class CourseProfile:Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<UpdateCourseDto, Course>();
        }
    }
}
