using System.ComponentModel.DataAnnotations;
using Test.Data.Entities;

namespace TestWebAPI.Models.Requests
{
    public class AddCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
        
    }
}
