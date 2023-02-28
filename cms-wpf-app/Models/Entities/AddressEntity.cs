using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cms_wpf_app.Models.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid CustomerId { get; set; } 

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string StreetName { get; set; } = string.Empty;

        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        public ICollection<CustomerEntity> Customers = new HashSet<CustomerEntity>();
        
    }
}
