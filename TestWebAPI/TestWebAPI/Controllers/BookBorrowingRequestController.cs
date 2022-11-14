using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Extensions;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services.Implements;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookBorrowingRequestController : ControllerBase
    {
        private IBookBorrowingRequestService _bookBorrowingRequestService;
        private IUsersService _usersService;

        public BookBorrowingRequestController(IBookBorrowingRequestService bookBorrowingRequestService, IUsersService usersService)
        {
            _bookBorrowingRequestService = bookBorrowingRequestService;
            _usersService = usersService;
        }

        [HttpPost]
        [Authorize(Roles = "NormalUser")]
        public ActionResult Create([FromBody]BookRequest bookRequestModel)
        {
            if (bookRequestModel == null) return BadRequest();

            var userId = this.GetCurrentLoginUserId();

            if(userId != null)
            {
                var user = _usersService.GetUserById(userId);

                if(user != null)
                {
                    var data = _bookBorrowingRequestService.Create(bookRequestModel, user);

                    return data != null ? Ok(data) : NotFound();
                }

                return BadRequest();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Update(int id, [FromBody] ApproveBookRequest bookRequestUpdateModel)
        {
            var userId = this.GetCurrentLoginUserId();

            if (userId == null)
            {
                return NotFound();
            }
            else
            {
                var user = _usersService.GetUserById(userId.Value);

                if (user != null)
                {
                    var data = _bookBorrowingRequestService.Approve(id, bookRequestUpdateModel, user);

                    return data != null ? Ok(data) : BadRequest("Bad request");
                }

                return NotFound();
            }
        }
    }
}
