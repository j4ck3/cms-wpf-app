using cms_wpf_app.Models.Entities;
using System;
using System.Collections.Generic;

namespace cms_wpf_app.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public Guid CustomerId { get; set; }
        public string UserName{ get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string OrderMessage { get; set; } = string.Empty;
        public List<OrderCommentEntity> Comments { get; set; }
    }
}
