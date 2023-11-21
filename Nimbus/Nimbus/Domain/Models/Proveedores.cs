namespace Nimbus.Nimbus.Domain.Models;

public class Proveedores
{
    public int ProveedorId  { get; set; }
    
    public string Name { get; set; }

    public string urlLogo { get; set; }
    
    public DateTime DateCreate { get; set; }

    public DateTime? DateUpdate { get; set; }
    
}