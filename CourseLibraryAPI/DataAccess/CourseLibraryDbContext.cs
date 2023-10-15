using CourseLibraryAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseLibraryAPI.DataAccess
{
    public class CourseLibraryDbContext:DbContext
    {
        public CourseLibraryDbContext(DbContextOptions<CourseLibraryDbContext> options):base(options)
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }  
    }
}
