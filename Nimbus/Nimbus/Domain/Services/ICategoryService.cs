using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services.Communication;

namespace Nimbus.Nimbus.Domain.Services;

public interface ICategoryService
{
    /// <summary>
    /// Obtiene todas las categorías.
    /// </summary>
    Task<IEnumerable<Category>> ListAsync();

    /// <summary>
    /// Obtienes las categorias asociadas a un Proveedor (posible implementacion)
    /// </summary>
    Task<IEnumerable<Category>> ListByProveedorIdAsync(int proveedorId);
    

    /// <summary>
    /// Guarda una nueva categoría.
    /// </summary>
    /// <param name="category">Instancia de Categoría a guardar.</param>
    Task<CategoryResponse> SaveAsync(Category category);

    /// <summary>
    /// Obtiene una categoría por su identificador único.
    /// </summary>
    /// <param name="categoryId">Identificador de la categoría a obtener.</param>
    Task<CategoryResponse> GetByIdAsync(int categoryId);

    /// <summary>
    /// Actualiza la información de una categoría existente.
    /// </summary>
    /// <param name="categoryId">Identificador de la categoría a actualizar.</param>
    /// <param name="category">Instancia de Categoría con la información actualizada.</param>
    Task<CategoryResponse> UpdateAsync(int categoryId, Category category);

    /// <summary>
    /// Elimina una categoría existente.
    /// </summary>
    /// <param name="categoryId">Identificador de la categoría a eliminar.</param>
    Task<CategoryResponse> DeleteAsync(int categoryId);
} 
