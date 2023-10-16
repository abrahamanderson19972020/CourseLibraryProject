using CourseLibraryAPI.DataAccess;
using CourseLibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLibraryAPI.Business.Abstract
{
    public class EfCourseRepositoryDal : ICourseRepositoryDal
    {
        private readonly CourseLibraryDbContext _context;

        public EfCourseRepositoryDal(CourseLibraryDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AuthorExistsAsync(Guid authorId)
        {
            var result =  await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
            return result != null;
        }
        public async Task<Author> GetAuthorByIdAsync(Guid authorId)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
        }

        public async Task<ICollection<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.Include(a => a.Courses).ToListAsync();
        }

        public async Task DeleteAuthor(Guid authorId)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == authorId);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public async Task AddAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAuthor(Author author)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(a=> a.Id == author.Id);
            if(result != null)
            {
                result.Firstname = String.IsNullOrEmpty(author.Firstname) ? result.Firstname : author.Firstname;
                result.Lastname = String.IsNullOrEmpty(author.Lastname) ? result.Lastname : author.Lastname;
                result.DateOfBirth = author.DateOfBirth;
                result.Courses = author.Courses.Count> 1 ? author.Courses: result.Courses;
                result.MainCategory = String.IsNullOrEmpty(author.MainCategory) ? result.MainCategory : author.MainCategory;
                await _context.SaveChangesAsync();
            }
        }


        public async Task<ICollection<Course>> GetCourseAsync(Guid authorId)
        {
            return await _context.Courses.Where<Course>(c => c.AuthorId == authorId).ToListAsync();  
        }

        public async Task<Course> GetCourseByIdAsync(Guid courseId, Guid authorId)

        {
            if (authorId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(authorId));
            }

            if (courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            return await _context.Courses.Where(c => c.AuthorId == authorId && c.Id == courseId).FirstOrDefaultAsync();

        }

        public async Task AddCourse(Guid authorId,Course course)
        {
            course.AuthorId = authorId;
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourse(Course course)
        {
             var result =await _context.Courses.FirstOrDefaultAsync(c=>c.Id == course.Id);
            if(result != null)
            {
                _context.Courses.Remove(result);
                await _context.SaveChangesAsync();
            }
 
        }

        public async Task UpdateCourse(Course course)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
            if(result != null)
            {
                result.AuthorId = course.AuthorId;  
                result.Description = String.IsNullOrEmpty(course.Description) ? result.Description : result.Description;
                result.Title = String.IsNullOrEmpty(course.Title) ? result.Title : result.Title;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
