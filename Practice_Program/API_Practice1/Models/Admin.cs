﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_Practice1.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        [Required]
        public string AdminFname { get; set; }

        public string? AdminLname { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string AdminEmail { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{8,}$")]
        public string AdminPasscode { get; set; }

        [ForeignKey("MasterAdmin")]
        public int? MasterAdminId { get; set; }

        [JsonIgnore]
        public virtual Admin MasterAdmin { get; set; }

        [InverseProperty("MasterAdmin")]
        [JsonIgnore]
        public virtual List<Admin>? ManagedAdmins { get; set; }
    }
}
