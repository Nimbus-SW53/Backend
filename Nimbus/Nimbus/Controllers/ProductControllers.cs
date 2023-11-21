using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Resources;
using Nimbus.Shared.Extensions;

namespace Nimbus.Nimbus.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductControllers:ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductControllers(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    /// <summary>
    ///  Get all Product 
    /// </summary>
    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var producto = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(producto);

        return resources;
    }

    
    /// <summary>
    ///  Get all Product with id 
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IEnumerable<ProductResource>> ListByCategoryIdAsync(int categoryId)
    {
        var producto = await _productService.ListByCategoryIdAsync(categoryId);
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(producto);
        return resources;
    }
    
    // POST: api/Product
    /// <summary>
    /// Create a new Product.
    /// </summary>
    /// <response code="200">Returns newly created product.</response>
    /// <response code="400">If the product is null or the required fields are empty</response>
    /// <response code="500">Unexpected error, maybe database is down</response>

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var product = _mapper.Map<SaveProductResource, Product>(resource);

        var results = await _productService.SaveAsync(product);

        if (!results.Success)
        {
            return BadRequest(results.Message);
        }

        var productResource = _mapper.Map<Product, ProductResource>(results.Resource);

        return Ok(productResource);
    }
}