using AutoMapper;
using CourseLibraryAPI.Business.Abstract;
using CourseLibraryAPI.Models.DTOs;
using CourseLibraryAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibraryAPI.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseRepositoryDal _repositoryDal;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorsController> _logger;
        public AuthorsController(ICourseRepositoryDal repositoryDal, IMapper  mapper, ILogger<AuthorsController> logger)
        {
            _repositoryDal = repositoryDal;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Author>>> GetAllAuthors()
        {
            var cities = await _repositoryDal.GetAuthorsAsync();
            if (cities == null)
            {
                _logger.LogError("Could not get authors");
                return NotFound();
            }
            _logger.LogInformation("All Authors are listed" +cities.ToString());
            return Ok(cities);
        }
        [HttpGet("{authorId}")]
        public async Task<ActionResult<Author>> GetAuthor(Guid authorId)
        {
            var author = await _repositoryDal.GetAuthorByIdAsync(authorId);
            if (author == null)
            {
                _logger.LogCritical($"No author wiht id {authorId}");
                return NotFound();
            }
            _logger.LogInformation("Author found with details "+ author.ToString());
            return Ok(author);
        }
        [HttpPost("addauthor")]
        public async Task<ActionResult> AddNewAuthor(AuthorDto author)
        {
            var authorToAdd = _mapper.Map<Author>(author);
            await _repositoryDal.AddAuthor(authorToAdd);
            _logger.LogInformation("New Author with details " + authorToAdd.ToString());
            return Ok(authorToAdd);
        }
        [HttpPut("updateauthor")]
        public async Task<ActionResult> UpdateAuthor(UpdateAuthorDto author)
        {
            await _repositoryDal.UpdateAuthor(author);
            _logger.LogInformation("Author is updated with details " + author.ToString());
            return NoContent();
        }
        [HttpDelete("deleteauthor")]
        public async Task<ActionResult> DeleteAuthor(Guid authorId)
        {
            await _repositoryDal.DeleteAuthor(authorId);
            _logger.LogInformation($"Author is updated with id {authorId} " );
            return NoContent(); 
        }

    }
}
