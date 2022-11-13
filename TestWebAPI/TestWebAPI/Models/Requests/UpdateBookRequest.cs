using System.ComponentModel.DataAnnotations;
using Test.Data.Entities;

namespace TestWebAPI.Models.Requests
{
    public class UpdateBookRequest
    {
        public string BookTitle { get; set; }
        
        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
