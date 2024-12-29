using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Enum
{
    public enum ShippingStatus
    {
        Pending,              // Gözləmədə
        Shipped,              // Göndərildi
        InTransit,            // Yolda
        OutForDelivery,       // Çatdırılmağa çıxarıldı
        Delivered,            // Təhvil verildi
        Returned,             // Geri qaytarıldı
        Failed                // Çatdırılma uğursuz oldu
    }
}
