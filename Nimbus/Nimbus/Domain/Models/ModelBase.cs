namespace Nimbus.Nimbus.Domain.Models;



public class ModelBase
{
    public int Id { get; set; }

    public DateTime DateCreate { get; set; }

    public DateTime? DateUpdate { get; set; }

    public bool IsActive { get; set; }
}