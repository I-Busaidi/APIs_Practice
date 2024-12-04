using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Practice1.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string AuthorName { get; set; }
        public int TotalCopies { get; set; } = 0;
        public int BorrowedCopies { get; set; } = 0;

        [Required]
        public int BorrowPeriod { get; set; }

        [Required]
        public decimal CopyPrice { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CatId { get; set; }

        [JsonIgnore]
        public virtual Category Category { get; set; }

        [JsonIgnore]
        public virtual ICollection<Borrow>? Borrows { get; set; }
    }
}
