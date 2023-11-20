using Nimbus.Nimbus.Domain.Models;

namespace Nimbus.Nimbus.Domain.Repositories;

public interface ICategoryRepository
{
    /// <summary>
    /// Obtiene todas las categorías en el sistema.
    /// </summary>
    Task<IEnumerable<Category>> ListAsync();

    /// <summary>
    /// Agrega una nueva categoría al sistema.
    /// </summary>
    Task AddAsync(Category category);

    /// <summary>
    /// Busca una categoría por su identificador único.
    /// </summary>
    Task<Category> FindByIdAsync(int categoryId);

    /// <summary>
    /// Actualiza la información de una categoría existente.
    /// </summary>
    void Update(Category category);

    /// <summary>
    /// Elimina una categoría del sistema.
    /// </summary>
    void Remove(Category category);
    
    /// <summary>
    /// Busca categorias asociados a un proveedor específico.
    /// </summary>
    Task<IEnumerable<Category>> FindByProveedorIdAsync(int proveedorId);

}