using CourseLibraryAPI.Business.Abstract;
using CourseLibraryAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibraryAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepositoryDal _repositoryDal;
        private readonly ILogger<CoursesController> _logger;
        public CoursesController(ICourseRepositoryDal repositoryDal, ILogger<CoursesController> logger)
        {
            _repositoryDal = repositoryDal;
            _logger = logger;   
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Course>>> GetAllCourses(Guid authorId)
        {
            var courses = await _repositoryDal.GetCourseAsync(authorId);
            if(courses == null)
            {
                return NotFound("No courses found");
                _logger.LogCritical("No courses foind");
            }
            _logger.LogInformation(courses.ToString()); 
            return Ok(courses);
        }
    }
}
