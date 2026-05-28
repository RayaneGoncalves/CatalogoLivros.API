using CatalogoLivros.API.Models;
using CatalogoLivros.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoLivros.API.Controllers;

[ApiController]
[Route("autores")]
public class AutoresController : ControllerBase
{
    private readonly AutorService _autorService;

    public AutoresController(AutorService autorService)
    {
        _autorService = autorService;
    }

    [HttpGet]
    public async Task<List<Autor>> Get() =>
        await _autorService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Autor>> Get(string id)
    {
        var autor = await _autorService.GetAsync(id);
        if (autor is null) return NotFound();
        return autor;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Autor autor)
    {
        await _autorService.CreateAsync(autor);
        return CreatedAtAction(nameof(Get), new { id = autor.Id }, autor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Autor autor)
    {
        var existing = await _autorService.GetAsync(id);
        if (existing is null) return NotFound();
        autor.Id = id;
        await _autorService.UpdateAsync(id, autor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var autor = await _autorService.GetAsync(id);
        if (autor is null) return NotFound();
        await _autorService.RemoveAsync(id);
        return NoContent();
    }
}