using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IProductRepository
    {
        Task<Domain.Entities.Product> GetByIdAsync(int id);
        Task<IEnumerable<Domain.Entities.Product>> GetAllAsync();
        Task AddAsync(Domain.Entities.Product product);
        Task UpdateAsync(Domain.Entities.Product product);
        Task DeleteAsync(Domain.Entities.Product product);
    }
}
