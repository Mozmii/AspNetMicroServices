using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Enum
{
    public enum StatusCode
    {
        Continue = 100,
        Ok = 200,
        RecordSave = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        AlreadyExist = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        InternalServerError = 500,
        ServerUnavailable = 503,
        GatwayTimeout = 504
    }
}
