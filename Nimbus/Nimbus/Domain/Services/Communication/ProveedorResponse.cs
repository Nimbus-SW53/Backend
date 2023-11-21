
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Shared.Domain.Services.Communication;

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