using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.Foundations.Mapper.Enum
{
    public static class ResponseMessage
    {
        public const string NotFound = "Not Found!";
        public const string BadRequest = "Bad Request!";
        public const string AlreadyExists = "Already Exists!";
        public const string InternalServerError = "Internal Server Exception!";
        public const string Success = "Action Done Successfully!";
        public const string CreateSuccess = "Record Saved Successfully!";
        public const string UpdateSuccess = "Record Update Successfully!";
        public const string DeleteSuccess = "Record Delete Successfully!";
        public const string GetById = "Record does not exists against this ID!";
        public const string NoDataAssigned = "No Roles Assigned Against This User!";
        public const string NoContentAginstId = "Cannot be deleted as this record is linked to a User.";
    }
}
