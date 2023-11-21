
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Domain.Services.Communication;
using Nimbus.Shared.Persistance.Repositories;

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

            // Asigna el título y la descripción
            string title = category.Title;
            string description = category.Description;
            
            if (category.Id > 0)
            {
                _categoryRepository.Update(category); // Actualizar si ya existe
            }
            else
            {
                await _categoryRepository.AddAsync(category); // Agregar si es nuevo
            }
            
            await _unitOfWork.CompleteAsync(); // Asegúrate de tener _unitOfWork configurado en tu clase

            // Puedes devolver la respuesta con la categoría guardada
            return new CategoryResponse(category);
        }
        catch (Exception e)
        {
            // Maneja cualquier error que pueda ocurrir durante el proceso de guardado
            return new CategoryResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public async Task<Category> FindByIdAsync(int categoryId)
    {
        return await _categoryRepository.FindByIdAsync(categoryId);
    }

    public async Task<CategoryResponse> UpdateAsync(int categoryId, Category category)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(categoryId);
        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        existingCategory.Title = UpdateIfValid(existingCategory.Title, category.Title);
        existingCategory.Description = UpdateIfValid(existingCategory.Description, category.Description);
        // Actualiza otras propiedades según sea necesario

        try
        {
            _categoryRepository.Update(existingCategory);
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<CategoryResponse> DeleteAsync(int categoryId)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(categoryId);
        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        try
        {
            _categoryRepository.Remove(existingCategory);
            await _unitOfWork.CompleteAsync();
            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }


    public async Task<IEnumerable<Category>> FindByNameAsync(string categoryName)
    {
        return await _categoryRepository.FindByNameAsync(categoryName);
    }
    

    private T UpdateIfValid<T>(T existingValue, T newValue)
    {
        if (IsValidForUpdate(newValue))
        {
            return newValue;
        }

        return existingValue;
    }

    // Método de utilidad para validar si un valor es válido para la actualización
    private bool IsValidForUpdate<T>(T value)
    {
        // Si el tipo es una cadena, verifica que no sea igual a "string"
        if (typeof(T) == typeof(string))
        {
            return value != null && !value.Equals("string");
        }
        // Si el tipo es numérico (en este caso, solo int), verifica que no sea igual a 0
        else if (typeof(T) == typeof(int))
        {
            return !EqualityComparer<T>.Default.Equals(value, default(T));
        }
        // Otros tipos
        else
        {
            return value != null && !value.Equals(default(T));
        }
    }
}