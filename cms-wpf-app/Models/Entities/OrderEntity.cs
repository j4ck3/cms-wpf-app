using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_wpf_app.Models.Entities;



public class OrderEntity
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string? Status { get; set; }
    public DateTime OrderDate { get; set; }

    [Column(TypeName = "nvarchar(1000)")]
    public string OrderMessage { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
    public CustomerEntity? Customer { get; set; }
    public ICollection<OrderCommentEntity>? Comments { get; set; }
}