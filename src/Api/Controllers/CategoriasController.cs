using Microsoft.AspNetCore.Mvc;
using PharmaPro.Application.DTOs;
using PharmaPro.Application.Ports.Inbound;

namespace PharmaPro.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaUseCase _categoriaUseCase;

    public CategoriasController(ICategoriaUseCase categoriaUseCase)
    {
        _categoriaUseCase = categoriaUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var categorias = await _categoriaUseCase.ObtenerTodosAsync();
        return Ok(categorias);
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetById(long id)
    {
        var categoria = await _categoriaUseCase.ObtenerPorIdAsync(id);
        if (categoria is null) return NotFound();

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoriaDto dto)
    {
        var categoria = await _categoriaUseCase.CrearAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, [FromBody] UpdateCategoriaDto dto)
    {
        var categoria = await _categoriaUseCase.ActualizarAsync(id, dto);
        if (categoria is null) return NotFound();

        return Ok(categoria);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        var deleted = await _categoriaUseCase.EliminarAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}
