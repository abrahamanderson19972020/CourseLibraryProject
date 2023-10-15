using CourseLibraryAPI.Models.Entities;

namespace CourseLibraryAPI.Business.Abstract
{
    public interface ICourseRepositoryDal
    {
        Task<ICollection<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(Guid authorId); 
        Task AddAuthor(Author author);
        Task DeleteAuthor(Guid authorId);
        Task UpdateAuthor(Author author);
        Task<ICollection<Course>> GetCourseAsync(Guid authorId);
        Task<Course> GetCourseByIdAsync(Guid courseId, Guid authorId);
        Task AddCourse(Guid authorId,Course course);  
        Task DeleteCourse(Course course);
        Task UpdateCourse(Course course);
        Task<bool> SaveChangesAsync();
        Task<bool> AuthorExistsAsync(Guid authorId);
    }
}
