using AutoMapper;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Resources;

namespace Nimbus.Nimbus.Mapping;

public class ModelToResourceProfile:Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
        CreateMap<Product, ProductResource>();
        CreateMap<Proveedores, ProveedorResource>();
        
        // Mapeo de Vehiculo a VehiculoResource con inclusión de miembros.
        
    }
    
}