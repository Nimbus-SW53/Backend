﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Resources;
using Nimbus.Shared.Extensions;

namespace Nimbus.Nimbus.Controllers;


[ApiController]
[Route("/api/v1/[controller]")]
public class ProveedoresControllers:ControllerBase
{
    private readonly IProveedorService _proveedorService;
    private readonly IMapper _mapper;

    public ProveedoresControllers(IProveedorService proveedorService, IMapper mapper)
    {
        _proveedorService = proveedorService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ProveedorResource>> GetAllAsync()
    {
        var proveedores = await _proveedorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Proveedores>, IEnumerable<ProveedorResource>>(proveedores);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProveedoresResource  resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var proveedor = _mapper.Map<SaveProveedoresResource, Proveedores>(resource);

        var results = await _proveedorService.SaveAsync(proveedor);

        if (!results.Success)
        {
            return BadRequest(results.Message);
        }

        var productResource = _mapper.Map<Proveedores, ProveedorResource>(results.Resource);

        return Ok(productResource);
    }
}