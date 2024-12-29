using E_CommerceSystem.Entities.Utilities.Results.Abstarct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceSystem.Entities.Utilities.Business
{
    public static class BusinessRules
        {
            public static IResult Check(params IResult[] results)
            {
                foreach (var result in results)
                {
                    if (!result.Success)
                    {
                        return new ErrorResult();
                    }
                }
                return new SuccessResult();
            }
        }
}
