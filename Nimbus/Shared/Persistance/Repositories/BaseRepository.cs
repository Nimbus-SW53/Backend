using Nimbus.Shared.Persistance.Contexts;

namespace Nimbus.Shared.Persistance.Repositories;

public class BaseRepository
{
    /// <summary>
    /// El contexto de la aplicación.
    /// </summary>
    protected readonly AppDbContext _context;
    
    /// <summary>
    /// Constructor que inicializa el contexto de la aplicación.
    /// </summary>
    /// <param name="context">El contexto de la aplicación.</param>
    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}