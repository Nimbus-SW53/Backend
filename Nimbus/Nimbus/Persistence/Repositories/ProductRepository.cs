
using Microsoft.EntityFrameworkCore;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Shared.Persistance.Contexts;
using Nimbus.Shared.Persistance.Repositories;

namespace Nimbus.Nimbus.Persistence.Repositories;

public class ProductRepository: BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Product> FindByIdAsync(int? productid)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }
}