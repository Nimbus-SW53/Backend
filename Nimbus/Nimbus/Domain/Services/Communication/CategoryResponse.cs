
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Shared.Domain.Services.Communication;

namespace Nimbus.Nimbus.Domain.Services.Communication;

public class CategoryResponse:BaseResponse<Category>

{
    public CategoryResponse(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor para una respuesta exitosa.
    /// </summary>
    /// <param name="resource">Recursos relacionados con la respuesta.</param>
    public CategoryResponse(Category resource) : base(resource)
    {
    }
    
}