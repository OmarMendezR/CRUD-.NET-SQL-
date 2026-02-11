using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        void Update(Product product);
        Task SoftDeleteAsync(Product product);
        Task SaveChangesAsync();
    }
}
