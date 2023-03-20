using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_wpf_app.Models.Entities
{
    public class OrderCommentEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        public virtual CustomerEntity Customer { get; set; } = null!;

        [Required]
        public int OrderEntityId { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Message { get; set; } = string.Empty;

        public DateTime MessageDate { get; set; }

    }
}
