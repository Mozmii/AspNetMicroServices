using Admins.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admins.InfraStructure.Repository.AdminRepository.CategoryRepository
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAllAsyncFilter(int StartForm, int? EndTo, string Search)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
