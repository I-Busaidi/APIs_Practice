﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API_Practice1.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string CatName { get; set; }

        public int NumOfBooks { get; set; } = 0;

        public virtual ICollection<Book> Books { get; set; }
    }
}
