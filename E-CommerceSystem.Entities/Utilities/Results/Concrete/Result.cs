using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
    }
}
