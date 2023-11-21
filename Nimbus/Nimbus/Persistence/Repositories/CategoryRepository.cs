using AutoYa_Backend.Shared.Domain.Services.Communication;
using AutoYa_Backend.Shared.Persistence.Contexts;
using AutoYa_Backend.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;

namespace Nimbus.Nimbus.Persistence.Repositories;

public class CategoryRepository:BaseRepository,ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _context.Categories.ToListAsync();
    }

  

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category) ;
    }

    public async Task<Category> FindByIdAsync(int categoryId)
    {
        return await _context.Categories.FindAsync(categoryId);
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
    }

    public void Remove(Category category)
    {
        _context.Categories.Remove(category);
    }

    public async Task<IEnumerable<Category>> FindByNameAsync(string categoryName)
    {
        return await _context.Categories.Where(a => a.Title == categoryName).ToListAsync();
    }
}