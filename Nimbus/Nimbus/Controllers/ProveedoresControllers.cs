using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Nimbus.Domain.Models;
using Nimbus.Nimbus.Domain.Services;
using Nimbus.Nimbus.Resources;

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
    
}