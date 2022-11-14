using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Entities
{
    public class BookBorrowingRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }
        //public int UserId { get; set; }
        public User RequestUser { get; set; }
        public User? Approver { get; set; }
        public DateTime? BorrowingDate { get; set; }
        public bool Status { get; set; }
    }
}
