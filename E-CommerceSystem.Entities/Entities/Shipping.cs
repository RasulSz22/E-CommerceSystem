using E_CommerceSystem.Entities.Common;
using E_CommerceSystem.Entities.Enum;

namespace E_CommerceSystem.Entities.Entities
{
    public class Shipping:BaseEntity
    {
        public string ShippingAddress { get; set; }
        public ShippingStatus Status { get; set; }       //todo enum olacaq
        public string TrackingNumber { get; set; }
        public  int OrderId { get; set; }
        public  Order Order { get; set; }
    }
}
