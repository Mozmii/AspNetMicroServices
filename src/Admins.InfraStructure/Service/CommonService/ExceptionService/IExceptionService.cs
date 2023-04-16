using Admins.Foundations.Mapper.ViewModels.CommonViewModel.Exception;
using Admins.Foundations.Mapper.ViewModels.CommonViewModel.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.InfraStructure.Service.CommonService.ExceptionService
{
    public interface IExceptionService
    {
        public Task<ResponseModel> CreateException(ExceptionCreate exceptionCreate);
    }
}
