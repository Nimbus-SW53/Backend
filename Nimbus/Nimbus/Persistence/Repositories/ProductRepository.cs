
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

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }
}