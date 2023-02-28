using System.ComponentModel.DataAnnotations.Schema;

namespace cms_wpf_app.Models.Entities
{
    public class OrdersEntity
    {

        public int Id { get; set; }

        public int UserId { get; set; }


        [Column(TypeName = "nvarchar(15)")]
        public string Status { get; set; } = string.Empty;

        [Column(TypeName = "datetime")]
        public string OrderDate { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(1000)")]
        public string Message { get; set; } = string.Empty;
    }
}
