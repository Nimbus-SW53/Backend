using Nimbus.Nimbus.Domain.Models;
namespace Nimbus.Nimbus.Domain.Repositories;

public interface IProductRepository
{   
    /// <summary>
    /// Buscar un producto por su ID.
    /// </summary>
    Task<Product> FindByIdAsync(int? productid);
    
    /// <summary>
    /// Obtiene todos los productos registrados.
    /// </summary>
    Task<IEnumerable<Product>> ListAsync();
    
    /// <summary>
    /// Busca productos asociados a una categoria específica.
    /// </summary>
    Task<IEnumerable<Product>> FindByCategoryIdAsync(int categoryId);

    void Update(Product product);


    Task AddAsync(Product product);
}