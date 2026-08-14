using Microsoft.AspNetCore.Mvc;
using PharmaPro.Application.DTOs;
using PharmaPro.Application.Ports.Inbound;

namespace PharmaPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedoresController : ControllerBase
{
    private readonly IProveedorUseCase _proveedorUseCase;

    public ProveedoresController(IProveedorUseCase proveedorUseCase)
    {
        _proveedorUseCase = proveedorUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var proveedores = await _proveedorUseCase.ObtenerTodosAsync();
        return Ok(proveedores);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var proveedor = await _proveedorUseCase.ObtenerPorIdAsync(id);
        if (proveedor is null) return NotFound();

        return Ok(proveedor);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProveedorDto dto)
    {
        var proveedor = await _proveedorUseCase.CrearAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = proveedor.Id }, proveedor);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateProveedorDto dto)
    {
        var proveedor = await _proveedorUseCase.ActualizarAsync(id, dto);
        if (proveedor is null) return NotFound();

        return Ok(proveedor);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _proveedorUseCase.EliminarAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
