using System.ComponentModel.DataAnnotations;
using Test.Data.Entities;

namespace TestWebAPI.Models.Requests
{
    public class UpdateCategoryRequest
    {
        public string CategoryName { get; set; }
    }
}
