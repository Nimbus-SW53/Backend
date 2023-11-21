using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;

namespace Nimbus.Nimbus.Services;

public class ProveedorServices:IProveedorService
{

    private readonly IProveedorRepository _proveedorRepository;

    public ProveedorServices(IProveedorRepository proveedorRepository)
    {
        _proveedorRepository = proveedorRepository;
    }

    public async Task<IEnumerable<Proveedores>> ListAsync()
    {
        return await _proveedorRepository.ListAsync();
    }
}