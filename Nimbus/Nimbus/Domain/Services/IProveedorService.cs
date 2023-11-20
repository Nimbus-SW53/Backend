
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services.Communication;

namespace Nimbus.Nimbus.Domain.Services;

public class IProveedorService
{
    /// <summary>
    /// Obtiene todos los proveedores.
    /// </summary>
    Task<IEnumerable<Proveedores>> ListAsync();

    /// <summary>
    /// Obtiene los proveedores asosicados a una categoria.
    /// </summary>
    private Task<IEnumerable<Proveedores> ListByCategory(int categoriId);
    
    /// <summary>
    /// Guarda un nuevo proveedor.
    /// </summary>
    /// <param name="proveedor">Instancia de Proveedor a guardar.</param>
    Task<ProveedorResponse> SaveAsync(Proveedores proveedor);

    /// <summary>
    /// Obtiene un proveedor por su identificador único.
    /// </summary>
    /// <param name="proveedorId">Identificador del proveedor a obtener.</param>
    Task<ProveedorResponse> GetByIdAsync(int proveedorId);

    /// <summary>
    /// Actualiza la información de un proveedor existente.
    /// </summary>
    /// <param name="proveedorId">Identificador del proveedor a actualizar.</param>
    /// <param name="proveedor">Instancia de Proveedor con la información actualizada.</param>
    Task<ProveedorResponse> UpdateAsync(int proveedorId, Proveedores proveedor);

    /// <summary>
    /// Elimina un proveedor existente.
    /// </summary>
    /// <param name="proveedorId">Identificador del proveedor a eliminar.</param>
    Task<ProveedorResponse> DeleteAsync(int proveedorId);
}