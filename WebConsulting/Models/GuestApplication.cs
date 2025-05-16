using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebConsulting.Models
{
    public class GuestApplication
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty; // Инициализация

        [Required]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        public string? Question { get; set; } // Nullable

        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "В ожидании";

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeleteReason { get; set; } // Nullable
        public string? DeletedBy { get; set; }    // Nullable
    }
}