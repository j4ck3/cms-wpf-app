using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_wpf_app.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(150)")]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "char(13)")]
        public string? PhoneNumber { get; set; }

        public int AddressId { get; set; }

        public AddressEntity Address { get; set; } = null!;
    }
}
