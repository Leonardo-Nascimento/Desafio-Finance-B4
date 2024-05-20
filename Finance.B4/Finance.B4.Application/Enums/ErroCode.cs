using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.B4.Application.Enums
{
    public enum ErroCode
    {
        NotFout = 404,
        BadRequest = 400,
        Business = 422,
        Unauthorized = 401,
        InternalError = 500,
        Conflic = 409,
        ServiceUnavaliable = 503
    }
}
