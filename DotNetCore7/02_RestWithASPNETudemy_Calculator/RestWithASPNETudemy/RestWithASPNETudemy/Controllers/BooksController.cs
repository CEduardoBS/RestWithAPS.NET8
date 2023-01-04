using Microsoft.AspNetCore.Mvc;
using RestWithASPNETudemy.Business;
using RestWithASPNETudemy.Model;
using RestWithASPNETudemy.Repository;

namespace RestWithASPNETudemy.Controllers
{ 
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {

        private readonly ILogger<BooksController> _logger;

        private IBooksBusiness _booksBusiness;

        public BooksController(ILogger<BooksController> logger, IBooksBusiness books)
        {
            _logger = logger;
            _booksBusiness = books;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _booksBusiness.FindAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var books = _booksBusiness.FindById(id);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Books books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksBusiness.create(books));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Books books)
        {
            if (books == null) return BadRequest();
            return Ok(_booksBusiness.Update(books));
        }

        [HttpDelete("{id}")]
        public IActionResult Delet(long id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }

    }
}
