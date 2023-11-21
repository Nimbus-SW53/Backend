
using Microsoft.EntityFrameworkCore;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Shared.Persistance.Contexts;
using Nimbus.Shared.Persistance.Repositories;

namespace Nimbus.Nimbus.Persistence.Repositories;

public class ProveedorRepository:BaseRepository,IProveedorRepository
{
    public ProveedorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Proveedores>> ListAsync()
    {
        return await _context.proveedores.ToListAsync();
    }
}