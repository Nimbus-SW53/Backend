using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Domain.Services.Communication;
using Nimbus.Nimbus.Resources;
using Nimbus.Shared.Extensions;

namespace Nimbus.Nimbus.Controllers;



[ApiController]
[Route("/api/v1/[controller]")]
public class CategoryControllers:ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryControllers(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    /// <summary>
    ///  Get all Category 
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<CategoryResource>> GetAllAsync()
    {
        var categoria = await _categoryService.ListAsync();

        var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categoria);

        return resources;
    }
    
    /// <summary>
    ///  Get all Category with name 
    /// </summary>

    [HttpGet("{categoryName}")]
    public async Task<IEnumerable<CategoryResource>> GetByName(string categoriName)
    {
        var categoria = await _categoryService.FindByNameAsync(categoriName);

        var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categoria);

        return resources;
    }
    
    /// <summary>
    ///  Put all Category with id
    /// </summary>

    [HttpPut("{categoryId}")]
    public async Task<ActionResult<CategoryResponse>> UpdateCategory(int categoryId,
        [FromBody] SaveCategoryResource category)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var categoria = _mapper.Map<SaveCategoryResource, Category>(category);
        var result = await _categoryService.UpdateAsync(categoryId, categoria);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var categoriaResource = _mapper.Map<Category, CategoryResource>(result.Resource);

        return Ok(categoriaResource);
    }
    
    /// <summary>
    ///  Delete all Category with id 
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var categoriaResource = _mapper.Map<Category, CategoryResource>(result.Resource);
        return Ok(categoriaResource);
    }
    
    
    // POST: api/Category
    /// <summary>
    /// Create a new category.
    /// </summary>
    /// <response code="200">Returns newly created category.</response>
    /// <response code="400">If the category is null or the required fields are empty</response>
    /// <response code="500">Unexpected error, maybe database is down</response>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var category = _mapper.Map<SaveCategoryResource, Category>(resource);

        var results = await _categoryService.SaveAsync(category);

        if (!results.Success)
        {
            return BadRequest(results.Message);
        }

        var productResource = _mapper.Map<Category, CategoryResource>(results.Resource);

        return Ok(productResource);
    }

}