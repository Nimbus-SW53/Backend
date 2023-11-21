using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Domain.Services.Communication;
using Nimbus.Shared.Persistance.Repositories;

namespace Nimbus.Nimbus.Services;

public class ProveedorServices:IProveedorService
{

    private readonly IProveedorRepository _proveedorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProveedorServices(IProveedorRepository proveedorRepository)
    {
        _proveedorRepository = proveedorRepository;
    }

    public async Task<IEnumerable<Proveedores>> ListAsync()
    {
        return await _proveedorRepository.ListAsync();
    }

    public async Task<ProveedorResponse> SaveAsync(Proveedores proveedores)
    {
        try
        {
            // Puedes realizar validaciones adicionales antes de guardar si es necesario

            // Asigna la fecha de creación si aún no está establecida
            if (proveedores.DateCreate == default(DateTime))
            {
                proveedores.DateCreate = DateTime.UtcNow;
            }

            // Asigna la fecha de actualización
            proveedores.DateUpdate = DateTime.UtcNow;

            // Asigna Name y urlLogo desde los parámetros
            string Name = proveedores.Name;
            string urlLogo = proveedores.urlLogo;
           
            if (proveedores.ProveedorId > 0)
            {
                _proveedorRepository.Update(proveedores); // Actualizar si ya existe
            }
            else
            {
                await _proveedorRepository.AddAsync(proveedores); // Agregar si es nuevo
            }
            
            await _unitOfWork.CompleteAsync(); // Asegúrate de tener _unitOfWork configurado en tu clase

            // Puedes devolver la respuesta con el proveedor guardado
            return new ProveedorResponse(proveedores);
        }
        catch (Exception e)
        {
            // Maneja cualquier error que pueda ocurrir durante el proceso de guardado
            return new ProveedorResponse($"An error occurred while saving the provider: {e.Message}");
        }
    }
}