using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseLibraryAPI.Models.Entities
{
    public class Course
    {
        [Key]
        public Guid Id { get; set; }
        [Required]  
        [MinLength(1)]
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }      
        public Guid AuthorId { get; set; }
        public Course()
        {

        }
    }
}
