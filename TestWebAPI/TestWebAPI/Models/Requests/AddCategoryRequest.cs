using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.Models.Requests
{
    public class AddCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
