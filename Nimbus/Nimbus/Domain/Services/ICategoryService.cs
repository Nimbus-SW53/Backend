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
    /// Guarda una nueva categoría.
    /// </summary>
    /// <param name="category">Instancia de Categoría a guardar.</param>
    //Task<CategoryResponse> SaveAsync(Category category);

    /// <summary>
    /// Obtiene una categoría por su identificador único.
    /// </summary>
    /// <param name="categoryId">Identificador de la categoría a obtener.</param>
    Task<Category> FindByIdAsync(int categoryId);

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


    /// <summary>
    /// Busca categorías por su nombre.
    /// </summary>
    Task<IEnumerable<Category>> FindByNameAsync(string categoryName);

    Task<CategoryResponse> SaveAsync(Category category);

} 
