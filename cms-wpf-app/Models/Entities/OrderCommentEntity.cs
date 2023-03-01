using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_wpf_app.Models.Entities
{
    public class OrderCommentEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid CustomerId { get; set; }

        public int OrderId { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Message { get; set; } = string.Empty;

        public DateTime MessageDate { get; set; }

    }
}
