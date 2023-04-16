using Admins.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.InfraStructure
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<object> GetAllAsyncFilter(int StartForm, int? EndTo, string Search);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIDAsync(int ID);
        Task<int> CreateAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int ID);
    }
}
