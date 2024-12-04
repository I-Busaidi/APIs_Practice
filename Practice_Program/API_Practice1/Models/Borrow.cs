using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace API_Practice1.Models
{
    [PrimaryKey(nameof(BorrowId), nameof(UserId), nameof(BookId))]
    public class Borrow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BorrowId { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        public DateTime? ActualReturnDate { get; set; } = null;

        public bool IsReturned { get; set; } = false;

        public int? Rating { get; set; } = null;

        [ForeignKey("User")]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }

        [JsonIgnore]
        public virtual Book Book { get; set; }
    }
}
