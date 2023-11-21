using AutoYa_Backend.Shared.Persistence.Repositories;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Domain.Services.Communication;

namespace Nimbus.Nimbus.Services;

public class CategoryServices:ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CategoryServices(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }
    public async Task<CategoryResponse> SaveAsync(Category category)
    {
        try
        {
            // Puedes realizar validaciones adicionales antes de guardar si es necesario

            // Puedes asignar la fecha de creación si aún no está establecida
            if (category.DateCreate == default(DateTime))
            {
                category.DateCreate = DateTime.UtcNow;
            }

            // Puedes asignar la fecha de actualización si aún no está establecida
            if (!category.DateUpdate.HasValue)
            {
                category.DateUpdate = DateTime.UtcNow;
            }

            // Luego, guarda la categoría utilizando el repositorio
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync(); // Asegúrate de tener _unitOfWork configurado en tu clase

            return new CategoryResponse(category);
        }
        catch (Exception e)
        {
            // Maneja cualquier error que pueda ocurrir durante el proceso de guardado
            return new CategoryResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public Task<CategoryResponse> GetByIdAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> UpdateAsync(int categoryId, Category category)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResponse> DeleteAsync(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> FindByNameAsync(string categoryName)
    {
        throw new NotImplementedException();
    }
}