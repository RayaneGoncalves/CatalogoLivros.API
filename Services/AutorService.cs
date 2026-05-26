using CatalogoLivros.API.Models;
using MongoDB.Driver;

namespace CatalogoLivros.API.Services;

public class AutorService
{
    private readonly IMongoCollection<Autor> _autores;

    public AutorService(IConfiguration config)
    {
        var client = new MongoClient(config["MongoDB:ConnectionString"]);
        var database = client.GetDatabase(config["MongoDB:DatabaseName"]);
        _autores = database.GetCollection<Autor>("autores");
    }

    public async Task<List<Autor>> GetAsync() =>
        await _autores.Find(_ => true).ToListAsync();

    public async Task<Autor?> GetAsync(string id) =>
        await _autores.Find(a => a.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Autor autor) =>
        await _autores.InsertOneAsync(autor);

    public async Task UpdateAsync(string id, Autor autor) =>
        await _autores.ReplaceOneAsync(a => a.Id == id, autor);

    public async Task RemoveAsync(string id) =>
        await _autores.DeleteOneAsync(a => a.Id == id);
}