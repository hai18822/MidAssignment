using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.Models.Requests
{
    public class BookRequest
    {
        [Required]
        public List<int> BookIds { get; set; }
    }
}
