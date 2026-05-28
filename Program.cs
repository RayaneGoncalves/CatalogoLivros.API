using CatalogoLivros.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<AutorService>();
builder.Services.AddSingleton<LivroService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();