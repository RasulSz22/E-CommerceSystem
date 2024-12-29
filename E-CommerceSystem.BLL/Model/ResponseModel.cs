using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.BLL.Model
{
    public class ResponseModel<T>
    {
            public T Data { get; set; }
            public int StatusCode { get; set; }
    }
}
