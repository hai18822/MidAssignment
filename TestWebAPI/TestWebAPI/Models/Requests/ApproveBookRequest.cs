using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.Models.Requests
{
    public class ApproveBookRequest
    {
        [Required]
        public RequestBookStatus Status { get; set; }
    }
}
