namespace Nimbus.Nimbus.Resources;

public class SaveProductResource
{
    public string SoftwareName { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string UrlImagePreview{ get; set; }
    public DateTime DateCreate { get; set; }

    public DateTime? DateUpdate { get; set; }
}