using CatalogoLivros.API.Models;
using MongoDB.Driver;

namespace CatalogoLivros.API.Services;

public class LivroService
{
    private readonly IMongoCollection<Livro> _livros;

    public LivroService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _livros = database.GetCollection<Livro>("livros");
    }

    public async Task<List<Livro>> GetAsync() =>
        await _livros.Find(_ => true).ToListAsync();

    public async Task<Livro?> GetAsync(string id) =>
        await _livros.Find(l => l.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Livro livro) =>
        await _livros.InsertOneAsync(livro);

    public async Task UpdateAsync(string id, Livro livro) =>
        await _livros.ReplaceOneAsync(l => l.Id == id, livro);

    public async Task RemoveAsync(string id) =>
        await _livros.DeleteOneAsync(l => l.Id == id);
}