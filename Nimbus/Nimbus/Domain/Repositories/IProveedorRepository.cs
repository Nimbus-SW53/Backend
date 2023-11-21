using Nimbus.Nimbus.Domain.Models;

namespace Nimbus.Nimbus.Domain.Repositories;

public interface IProveedorRepository
{
/// <summary>
/// Obtiene todos los proveedores en el sistema.
/// </summary>
    Task<IEnumerable<Proveedores>> ListAsync();

    void Update(Proveedores proveedores);
    
    Task AddAsync(Proveedores proveedores);

}