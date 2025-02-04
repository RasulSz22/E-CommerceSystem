using E_CommerceSystem.Entities.Common;
using E_CommerceSystem.Entities.Enum;
using E_CommerceSystem.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Entities
{
    public class Payment:BaseEntity
    {
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
