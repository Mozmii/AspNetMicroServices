using Admins.Foundations.Mapper.ViewModels.CommonViewModel.Exception;
using Admins.Foundations.Mapper.ViewModels.CommonViewModel.ResponseModel;
using Admins.InfraStructure.Repository.CommonRepository.ExceptionRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.InfraStructure.Service.CommonService.ExceptionService
{
    public class ExceptionService : IExceptionService
    {
        private readonly IExceptionRepository _exceptionRepository;
        private readonly IMapper _mapper;

        public ExceptionService(IExceptionRepository exceptionRepository, IMapper mapper)
        {
            _exceptionRepository = exceptionRepository;
            _mapper = mapper;
        }

        public Task<ResponseModel> CreateException(ExceptionCreate exceptionCreate)
        {
            throw new NotImplementedException();
        }
    }
}
