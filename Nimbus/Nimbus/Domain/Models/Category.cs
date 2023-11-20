namespace Nimbus.Nimbus.Domain.Models;

public class Category :ModelBase
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set;}

    private List<Proveedores> _proveedores { get; set; }

}


