
using Nimbus.Nimbus.Domain.Models;

namespace Nimbus.Nimbus.Domain.Services;

public interface IProveedorService
{
    /// <summary>
    /// Obtiene todos los proveedores.
    /// </summary>
    Task<IEnumerable<Proveedores>> ListAsync();
}