using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }     //todo yeniden bax guid ede bilerem (dtolarda intledir)
        public DateTime CreatedTime { get; set; }
        public DateTime ModifierTime { get; set; } //todo yeniden bax
        public bool IsDelete { get; set; }  //todo yeniden bax
    }
}
