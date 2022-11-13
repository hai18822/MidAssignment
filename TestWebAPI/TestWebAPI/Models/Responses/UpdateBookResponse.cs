using Test.Data.Entities;

namespace TestWebAPI.Models.Responses
{
    public class UpdateBookResponse
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public Category Category { get; set; }
    }
}
