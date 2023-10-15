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
        public AuthorsController(ICourseRepositoryDal repositoryDal, IMapper  mapper)
        {
            _repositoryDal = repositoryDal;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Author>>> GetAllAuthors()
        {
            var cities = await _repositoryDal.GetAuthorsAsync();
            if (cities == null)
                return NotFound();
            return Ok(cities);
        }
        [HttpGet("{authorId}")]
        public async Task<ActionResult<Author>> GetAuthor(Guid authorId)
        {
            var author = await _repositoryDal.GetAuthorByIdAsync(authorId);
            if (author == null)
                return NotFound();
            return Ok(author);
        }
        [HttpPost("addauthor")]
        public async Task<ActionResult> AddNewAuthor(AuthorDto author)
        {
            var authorToAdd = _mapper.Map<Author>(author);
            await _repositoryDal.AddAuthor(authorToAdd);
            var authorToReturn = _mapper.Map<AuthorDto>(authorToAdd);
            return Ok(authorToReturn);
        }
    }
}
