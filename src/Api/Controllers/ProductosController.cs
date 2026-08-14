using Microsoft.AspNetCore.Mvc;
using PharmaPro.Application.DTOs;
using PharmaPro.Application.Ports.Inbound;

namespace PharmaPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoUseCase _productoUseCase;

    public ProductosController(IProductoUseCase productoUseCase)
    {
        _productoUseCase = productoUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var productos = await _productoUseCase.ObtenerTodosAsync();
        return Ok(productos);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var producto = await _productoUseCase.ObtenerPorIdAsync(id);
        if (producto == null) return NotFound();
        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductoDto dto)
    {
        var producto = await _productoUseCase.CrearProductoAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateProductoDto dto)
    {
        var producto = await _productoUseCase.ActualizarAsync(id, dto);
        if (producto == null) return NotFound();

        return Ok(producto);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _productoUseCase.EliminarAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
