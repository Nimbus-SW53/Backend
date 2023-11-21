using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services.Communication;

namespace Nimbus.Nimbus.Domain.Services;

public interface IProductService
{   
    /// <summary>
    /// Obtiene todos los productos.
    /// </summary>
    Task<IEnumerable<Product>> ListAsync();
    
    /// <summary>
    /// Obtiene los productos asociados a una categoria.
    /// </summary>
    Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
    
    /// <summary>
    /// Guarda un nuevo producto.
    /// </summary>
    /// <param name="product">Instancia de Producto a guardar.</param>
   Task<ProductResponse> SaveAsync(Product product);
}