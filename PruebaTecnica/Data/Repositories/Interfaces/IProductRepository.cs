using PruebaTecnica.Models;

namespace ProductApi.Data.Repositories.Interfaces
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
