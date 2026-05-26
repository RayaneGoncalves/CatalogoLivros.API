using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogoLivros.API.Models;

public class Livro
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Titulo { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int AnoPublicacao { get; set; }
    public string Sinopse { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)]
    public string AutorId { get; set; } = string.Empty;
}