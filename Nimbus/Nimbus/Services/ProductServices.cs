using AutoYa_Backend.Shared.Persistence.Repositories;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Domain.Services.Communication;

namespace Nimbus.Nimbus.Services;

public class ProductServices: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public Task<IEnumerable<Product>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductResponse> SaveAsync(Product alquiler)
    {
        throw new NotImplementedException();
    }
}