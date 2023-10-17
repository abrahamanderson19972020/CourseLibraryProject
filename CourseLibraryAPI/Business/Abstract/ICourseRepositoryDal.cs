﻿using CourseLibraryAPI.Models.Entities;

namespace CourseLibraryAPI.Business.Abstract
{
    public interface ICourseRepositoryDal
    {
        Task<ICollection<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(Guid authorId); 
        Task AddAuthor(Author author);
        Task DeleteAuthor(Guid authorId);
        Task UpdateAuthor(Author author);
        Task<ICollection<Course>> GetCoursesAsync(Guid authorId);
        Task<Course> GetCourseByIdAsync(Guid courseId, Guid authorId);
        Task<bool> AddCourse(Guid authorId,Course course);  
        Task<bool> DeleteCourse(Guid courseId);
        Task<bool> UpdateCourse(Course course);
        Task<bool> SaveChangesAsync();
        Task<bool> AuthorExistsAsync(Guid authorId);
    }
}
