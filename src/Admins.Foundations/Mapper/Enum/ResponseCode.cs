using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Enum
{
    public static class ResponseCode
    {
        public const int Continue = 100;
        public const int Ok = 200;
        public const int RecordSave = 201;
        public const int NoContent = 204;
        public const int BadRequest = 400;
        public const int Unauthorized = 401;
        public const int AlreadyExits = 403;
        public const int NotFound = 404;
        public const int MethodNotAllowed = 405;
        public const int InternalServerError = 500;
        public const int ServerUnavailable = 503;
        public const int GatwayTimeout = 504;
    }
}
