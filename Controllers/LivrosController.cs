using CatalogoLivros.API.Models;
using CatalogoLivros.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoLivros.API.Controllers;

[ApiController]
[Route("livros")]
public class LivrosController : ControllerBase
{
    private readonly LivroService _livroService;

    public LivrosController(LivroService livroService)
    {
        _livroService = livroService;
    }

    [HttpGet]
    public async Task<List<Livro>> Get() =>
        await _livroService.GetAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Livro>> Get(string id)
    {
        var livro = await _livroService.GetAsync(id);
        if (livro is null) return NotFound();
        return livro;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Livro livro)
    {
        await _livroService.CreateAsync(livro);
        return CreatedAtAction(nameof(Get), new { id = livro.Id }, livro);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, Livro livro)
    {
        var existing = await _livroService.GetAsync(id);
        if (existing is null) return NotFound();
        livro.Id = id;
        await _livroService.UpdateAsync(id, livro);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var livro = await _livroService.GetAsync(id);
        if (livro is null) return NotFound();
        await _livroService.RemoveAsync(id);
        return NoContent();
    }
}