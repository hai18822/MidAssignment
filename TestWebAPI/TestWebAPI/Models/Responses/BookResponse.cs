using Test.Data.Entities;

namespace TestWebAPI.Models.Responses
{
    public class BookResponse
    {
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public Category Category { get; set; }

        public bool IsDeleted { get; set; }

    }
}
