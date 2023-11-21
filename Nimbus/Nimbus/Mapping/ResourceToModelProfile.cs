using AutoMapper;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Resources;

namespace Nimbus.Nimbus.Mapping;

public class ResourceToModelProfile : Profile
{
    /// <summary>
    /// Inicializa una nueva instancia del perfil de mapeo de recursos de guardado a modelos de dominio.
    /// </summary>
    public ResourceToModelProfile()
    {
        CreateMap<SaveCategoryResource, Category>();
     
    }
}