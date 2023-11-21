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

    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var producto = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(producto);

        return resources;
    }


    [HttpGet("{id}")]
    public async Task<IEnumerable<ProductResource>> ListByCategoryIdAsync(int categoryId)
    {
        var producto = await _productService.ListByCategoryIdAsync(categoryId);
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(producto);
        return resources;
    }

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