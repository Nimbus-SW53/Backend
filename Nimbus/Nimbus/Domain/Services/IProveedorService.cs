
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services.Communication;

namespace Nimbus.Nimbus.Domain.Services;

public interface IProveedorService
{
    /// <summary>
    /// Obtiene todos los proveedores.
    /// </summary>
    Task<IEnumerable<Proveedores>> ListAsync();

    Task<ProveedorResponse> SaveAsync(Proveedores proveedores);
}