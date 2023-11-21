using AutoYa_Backend.Shared.Domain.Services.Communication;
using Nimbus.Nimbus.Domain.Models;
namespace Nimbus.Nimbus.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    /// <summary>
    /// Constructor para una respuesta que indica un error.
    /// </summary>
    /// <param name="message">Mensaje de error.</param>
    public ProductResponse(string message) : base(message)
    {
    }

    /// <summary>
    /// Constructor para una respuesta exitosa.
    /// </summary>
    /// <param name="resource">Recursos relacionados con la respuesta.</param>
    public ProductResponse(Product resource) : base(resource)
    {
    }
}