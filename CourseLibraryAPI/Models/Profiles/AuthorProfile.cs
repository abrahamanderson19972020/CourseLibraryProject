using AutoMapper;
using CourseLibraryAPI.Models.DTOs;
using CourseLibraryAPI.Models.Entities;

namespace CourseLibraryAPI.Models.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
        }
        
    }
}
