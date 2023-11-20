using AutoYa_Backend.Shared.Domain.Services.Communication;
using Nimbus.Nimbus.Domain.Models;

namespace Nimbus.Nimbus.Domain.Services.Communication;

public class ProveedorResponse:BaseResponse<Proveedores>
{
    public ProveedorResponse(string message) : base(message)
    {
        
    }
    
    public ProveedorResponse(Proveedores resource) : base(resource)
    {
    }
}