﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebConsulting.Models;

[PrimaryKey("ApplicationId", "ServiceId")]
public partial class ApplicationService
{
    [Key]
    public int ApplicationId { get; set; }

    [Key]
    public int ServiceId { get; set; }

    public int Quantity { get; set; }

    [StringLength(500)]
    public string Notes { get; set; }

    [ForeignKey("ApplicationId")]
    [InverseProperty("ApplicationServices")]
    public virtual Application Application { get; set; }

    [ForeignKey("ServiceId")]
    [InverseProperty("ApplicationServices")]
    public virtual Service Service { get; set; }
}