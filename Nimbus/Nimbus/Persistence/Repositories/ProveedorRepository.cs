using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;

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