using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebConsulting.Models
{
    public class GuestApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public string Question { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(20)]
        public string Status { get; set; } = "В ожидании";

        public bool IsDeleted { get; set; } = false;

        [Column(TypeName = "datetime")]
        public DateTime? DeletedAt { get; set; }

        [StringLength(200)]
        public string DeleteReason { get; set; }

        [StringLength(100)]
        public string DeletedBy { get; set; }
    }
}