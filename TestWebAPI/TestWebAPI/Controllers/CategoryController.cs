using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestWebAPI.Models.Requests;
using TestWebAPI.Services;
using TestWebAPI.Services.Implements;
using TestWebAPI.Services.Interfaces;

namespace TestWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _categoryService.GetById(id);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPost("cat")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Add([FromBody] AddCategoryRequest categoryToAdd)
        {
            _categoryService.Add(categoryToAdd);
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int id)
        {
            var message = "Delete succeeded";

            try
            {
                var isSucceeded = _categoryService.Delete(id);

                return isSucceeded ? Ok(message) : NotFound();
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
                var isSucceeded = _categoryService.SoftDelete(id);

                return isSucceeded ? Ok(message) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Update(int id, [FromBody] UpdateCategoryRequest catUpdateModel)
        {
            if (catUpdateModel == null) return BadRequest();

            try
            {
                var data = _categoryService.Update(id, catUpdateModel);

                return data != null ? Ok(data) : NotFound();
            }
            catch
            {
                return BadRequest("Bad request");
            }
        }
    }
}
