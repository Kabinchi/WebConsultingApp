#nullable disable
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebConsulting.Models;

public partial class Application
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyAddress { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; } = "В ожидании";

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int? ServiceId { get; set; }

    // Новые поля для отмены заявок
    [Column(TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
    public string DeleteReason { get; set; }
    public string DeletedBy { get; set; } // "user" или "admin"
    public string DeletedByUserId { get; set; } // ID пользователя

    [ForeignKey("ServiceId")]
    public virtual Service Service { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}