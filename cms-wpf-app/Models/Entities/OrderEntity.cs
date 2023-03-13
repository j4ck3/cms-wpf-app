﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_wpf_app.Models.Entities;



public class OrderEntity
{
    public int Id { get; set; }

    public Guid CustomerId { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string? Status { get; set; }
    public DateTime OrderDate { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string OrderMessage { get; set; } = string.Empty;
}