using E_CommerceSystem.Entities.Common;
using E_CommerceSystem.Entities.Enum;

namespace E_CommerceSystem.Entities.Entities
{
    public class Shipping:BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ShippingTypes ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
    }
}
