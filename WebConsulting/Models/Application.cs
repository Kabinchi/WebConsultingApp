﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebConsulting.Models;

public partial class Application
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [StringLength(20)]
    public string Status { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Applications")]
    public virtual User User { get; set; }
}