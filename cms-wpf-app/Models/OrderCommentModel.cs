using System;

namespace cms_wpf_app.Models
{
    public class OrderCommentModel
    {

        public int Id { get; set; }

        public Guid CustomerId { get; set; }

        public string? UserName { get; set; }

        public int OrderId { get; set; }

        public string Message { get; set; } = string.Empty;

        public DateTime MessageDate { get; set; }

    }
}
