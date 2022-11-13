using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _bookService.InitData();
            return Ok("Test");
        }

        [HttpGet("book")]
        public async Task<ActionResult> Get()
        {
            var result = await _bookService.Get();
            return Ok(result);
        }

        [HttpGet("book/{bookId}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await _bookService.Get(id);

            return Ok(result);
        }

        [HttpPost("book")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> Add([FromBody] AddBookRequest bookToAdd)
        {
            await _bookService.Add(bookToAdd);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            var message = "Delete succeeded";

            try
            {
                var isSucceeded = _bookService.Delete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Update(int id, [FromBody] UpdateBookRequest bookUpdateModel)
        {
            if (bookUpdateModel == null) return BadRequest();

            try
            {
                var data = _bookService.Update(id, bookUpdateModel);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPut("softd/{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult SoftDelete(int id)
        {
            var message = "Delete succeeded";

            try
            {
                var isSucceeded = _bookService.SoftDelete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }
    }
}
