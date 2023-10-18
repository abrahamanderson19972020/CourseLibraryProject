using AutoMapper;
using CourseLibraryAPI.Business.Abstract;
using CourseLibraryAPI.Models.DTOs;
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
        private readonly IMapper _mapper;
        public CoursesController(ICourseRepositoryDal repositoryDal, ILogger<CoursesController> logger, IMapper mapper)
        {
            _repositoryDal = repositoryDal;
            _logger = logger;  
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Course>>> GetAllCourses(Guid authorId)
        {
            var courses = await _repositoryDal.GetCoursesAsync(authorId);
            if(courses == null)
            {
                return NotFound("No courses found");
                _logger.LogCritical("No courses foind");
            }
            _logger.LogInformation(courses.ToString()); 
            return Ok(courses);
        }

        [HttpGet("{authorId}/{courseId}")]
        public async Task<ActionResult<Course>> GetCourse(Guid courseId, Guid authorId)
        {
            var course = await _repositoryDal.GetCourseByIdAsync(courseId, authorId);   
            if(course == null)
            {
                _logger.LogError("No course found");
                return NotFound("No course found");
            }
            _logger.LogInformation("Course details "+ course.ToString());
            return Ok(course);
        }

        [HttpPost("addcourse")]
        public async Task<ActionResult> AddNewCourse(Guid authorId, CourseDto courseDto)
        {
            var courseToAdd = _mapper.Map<Course>(courseDto);
            courseToAdd.AuthorId = authorId;
            bool result = await _repositoryDal.AddCourse(authorId, courseToAdd);
            if(!result)
            {
                _logger.LogError("Could not add new course!");
                return BadRequest("Something wrong! Check author Id or course has required specifications");
            }
            _logger.LogInformation("New course is added with details as "+ courseToAdd.ToString());
            return NoContent();
        }

        [HttpPut("updatecourse")]
        public async Task<ActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            bool result = await _repositoryDal.UpdateCourse(updateCourseDto);
            if(result)
            {
                _logger.LogInformation("New course is updated with details as " + updateCourseDto.ToString());
                return NoContent();
            }
            else
            {
                _logger.LogError("Could not find and update course");
                return BadRequest("Could not updated! Check course details!");
            }
        }
        [HttpDelete("delete/{courseId}")]
        public async Task<ActionResult> DeleteSingleCourse(Guid courseId)
        {
            bool result = await _repositoryDal.DeleteCourse(courseId);  
            if (result)
            {
                _logger.LogInformation("Course is deleted with details with id" + courseId.ToString());
                return NoContent();
            }
            else
            {
                _logger.LogError("Could not delete course");
                return BadRequest("No course found with course course");
            }
        }

    }
}
