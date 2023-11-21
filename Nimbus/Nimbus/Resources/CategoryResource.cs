namespace Nimbus.Nimbus.Resources;

public class CategoryResource
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set;}
    
    public DateTime DateCreate { get; set; }

    public DateTime? DateUpdate { get; set; }
}