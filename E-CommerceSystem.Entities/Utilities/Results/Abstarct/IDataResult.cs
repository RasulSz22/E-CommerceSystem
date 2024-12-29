using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Utilities.Results.Abstarct
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
