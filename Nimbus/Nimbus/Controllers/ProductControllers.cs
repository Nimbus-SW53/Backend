using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Resources;

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
}