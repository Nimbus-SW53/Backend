using Nimbus.Nimbus.Domain.Models;

namespace Nimbus.Nimbus.Domain.Repositories;

public interface IProveedorRepository
{
/// <summary>
/// Obtiene todos los proveedores en el sistema.
/// </summary>
Task<IEnumerable<Proveedores>> ListAsync();

/// <summary>
/// Agrega un nuevo proveedor al sistema.
/// </summary>
Task AddAsync(Proveedores proveedor);

/// <summary>
/// Busca un proveedor por su identificador único.
/// </summary>
Task<Proveedores> FindByIdAsync(int proveedorId);

/// <summary>
/// Actualiza la información de un proveedor existente.
/// </summary>
void Update(Proveedores proveedor);

/// <summary>
/// Elimina un proveedor del sistema.
/// </summary>
void Remove(Proveedores proveedor);
}