namespace Nimbus.Nimbus.Domain.Models;

public class Category 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set;}
    
    public DateTime DateCreate { get; set; }

    public DateTime? DateUpdate { get; set; }

    private List<Product> _proveedores { get; set; }
    public List<Product> Proveedores { get; set; }
}


