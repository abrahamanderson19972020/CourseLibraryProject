namespace CourseLibraryAPI.Models.DTOs
{
    public class AuthorDto
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string MainCategory { get; set; } = string.Empty;
    }
}
