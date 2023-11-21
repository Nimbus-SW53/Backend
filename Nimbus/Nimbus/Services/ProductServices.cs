
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Repositories;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Domain.Services.Communication;
using Nimbus.Shared.Persistance.Repositories;

namespace Nimbus.Nimbus.Services;

public class ProductServices: IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
    {
        return await _productRepository.FindByCategoryIdAsync(categoryId);
    }



    public async Task<ProductResponse> SaveAsync(Product product)
    {
        try
        {
            // Puedes realizar validaciones adicionales antes de guardar si es necesario

            // Asigna la fecha de creación si aún no está establecida
            if (product.DateCreate == default(DateTime))
            {
                product.DateCreate = DateTime.UtcNow;
            }

            // Asigna la fecha de actualización
            product.DateUpdate = DateTime.UtcNow;

            // Si CategoryId está presente, asume que se proporcionó un ID de categoría y busca la categoría correspondiente
            if (product.CategoryId > 0)
            {
                product.Category = await _categoryRepository.FindByIdAsync(product.CategoryId);
            }

            // Asigna SoftwareName, Price y UrlImagePreview desde los parámetros
            string SoftwareName = product.SoftwareName;
            decimal Price = product.Price;
            string UrlImagePreview = product.UrlImagePreview;

            // Guarda el producto utilizando el repositorio
            if (product.Id > 0)
            {
                _productRepository.Update(product); // Actualizar si ya existe
            }
            else
            {
                await _productRepository.AddAsync(product); // Agregar si es nuevo
            }

            await _unitOfWork.CompleteAsync(); // Asegúrate de tener _unitOfWork configurado en tu clase

            // Puedes devolver la respuesta con el producto guardado
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            // Maneja cualquier error que pueda ocurrir durante el proceso de guardado
            return new ProductResponse($"An error occurred while saving the product: {e.Message}");
        }
    }
}
