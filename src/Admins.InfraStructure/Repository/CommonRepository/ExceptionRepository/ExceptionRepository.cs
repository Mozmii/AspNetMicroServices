using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.InfraStructure.Repository.CommonRepository.ExceptionRepository
{
    class ExceptionRepository : BaseRepository, IExceptionRepository
    {
        public ExceptionRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public Task<int> CreateAsync(Domain.Models.Common.Exception entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.Common.Exception>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAllAsyncFilter(int StartForm, int? EndTo, string Search)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Models.Common.Exception> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Domain.Models.Common.Exception entity)
        {
            throw new NotImplementedException();
        }
    }
}
