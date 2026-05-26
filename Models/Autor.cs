using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogoLivros.API.Models;

public class Autor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Nacionalidade { get; set; } = string.Empty;
    public int AnoNascimento { get; set; }
}