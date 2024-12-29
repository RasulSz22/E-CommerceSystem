using E_CommerceSystem.Entities.Common;
using E_CommerceSystem.Entities.Identity;

namespace E_CommerceSystem.Entities.Entities
{
    public class Order:BaseEntity
    {
        public string OrderNotes { get; set; }
        public int Discount { get; set; }
        public double TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public  int PaymentId { get; set; } 
        public  Payment Payment { get; set; }
        public string AppUserId {  get; set; }
        public AppUser AppUser {  get; set; }
        //public  int ShippingId { get; set; }
        //public  Shipping Shipping { get; set; } 
    }
}