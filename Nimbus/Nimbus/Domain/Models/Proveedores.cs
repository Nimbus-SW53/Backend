namespace Nimbus.Nimbus.Domain.Models;

public class Proveedores
{
    public int ProveedorId  { get; set; }
    
    public string Name { get; set; }

    public int Year { get; set; }

    public float Cost { get; set; }
  
    public int? Reviews { get; set; }

    public Category Category { get; set; }

}