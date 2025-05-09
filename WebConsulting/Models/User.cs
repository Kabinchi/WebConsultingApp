﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebConsulting.Models;

[Index("Email", Name = "UQ__Users__A9D10534DC650A90", IsUnique = true)]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(255)]
    public string Password { get; set; }

    [Required]
    [StringLength(20)]
    public string Role { get; set; }

    [StringLength(20)]
    public string PhoneNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletedAt { get; set; }

    public bool IsDeleted { get; set; }

    [StringLength(200)]
    public string DeleteReason { get; set; }

    [StringLength(50)]
    public string DeletedBy { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    [InverseProperty("User")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}