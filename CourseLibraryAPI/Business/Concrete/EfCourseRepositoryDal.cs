using AutoMapper;
using CourseLibraryAPI.DataAccess;
using CourseLibraryAPI.Models.DTOs;
using CourseLibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLibraryAPI.Business.Abstract
{
    public class EfCourseRepositoryDal : ICourseRepositoryDal
    {
        private readonly CourseLibraryDbContext _context;
        private readonly IMapper _mapper;

        public EfCourseRepositoryDal(CourseLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

        public async Task UpdateAuthor(UpdateAuthorDto author)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(a=> a.Id == author.Id);
            if(result != null)
            {
                _mapper.Map(author, result);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<ICollection<Course>> GetCoursesAsync(Guid authorId)
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

        public async Task<bool> AddCourse(Guid authorId,Course course)
        {
            bool isAuthorValid = await AuthorExistsAsync(authorId);
            if(!isAuthorValid)
            {
                return isAuthorValid;
            }
            course.AuthorId = authorId;
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return isAuthorValid;
        }

        public async Task<bool> DeleteCourse(Guid courseId)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(c=>c.Id == courseId);
            if(result != null)
            {
                _context.Courses.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
 
        }

        public async Task<bool> UpdateCourse(UpdateCourseDto course)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(c => c.Id == course.Id);
            if(result != null)
            {
                _mapper.Map(course, result);
                await _context.SaveChangesAsync();
                return result != null;
            }
            return result != null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

    }
}
