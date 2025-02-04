using E_CommerceSystem.Entities.Common;
using E_CommerceSystem.Entities.Identity;

namespace E_CommerceSystem.Entities.Entities
{
    public class Order:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int PaymentId { get; set; }
        public string? DeliveryStatus { get; set; }
        public DateTime? DeliveryTime { get; set; }
    }
} 