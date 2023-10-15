using System.ComponentModel.DataAnnotations;

namespace CourseLibraryAPI.Models.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Firstname { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Lastname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string MainCategory { get; set; }
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public Author()
        {
         
        }
    }
}
