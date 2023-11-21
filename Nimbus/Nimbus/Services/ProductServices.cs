
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Domain.Services.Communication;
using Nimbus.Shared.Persistance.Repositories;

namespace Nimbus.Nimbus.Services;

public class ProductServices: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
    {
        return await _productRepository.FindByCategoryIdAsync(categoryId);
    }

    /*public async Task<ProductResponse> SaveAsync(Product alquiler)
    {
        return await _productRepository.;
    }*/
}