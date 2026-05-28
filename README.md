📚 Catálogo de Livros
API REST para gerenciamento de um catálogo pessoal de livros, desenvolvida com .NET 10, C# e MongoDB. Permite cadastrar autores e livros, editar informações e excluir registros através de uma interface web com navegação assíncrona.

Trabalho Prático — Arquitetura de Aplicações Web 2026.1


🛠️ Tecnologias
CamadaTecnologiaBackend / API.NET 10 com C# — Web APIBanco de dadosMongoDB 7 (via Docker)DocumentaçãoSwagger / OpenAPIFrontendHTML + JavaScript (Fetch API)ContainerizaçãoDocker + Docker Compose

📋 Pré-requisitos

.NET 10 SDK
Docker Desktop instalado e rodando


🚀 Como executar
1. Clone o repositório
bashgit clone https://github.com/seu-usuario/CatalogoLivros.git
cd CatalogoLivros
2. Suba o MongoDB com Docker
bashdocker compose up -d
Confirme que o container está rodando:
bashdocker ps
O container catalogo-mongo deve aparecer com status Up.
3. Rode a API
bashcd CatalogoLivros.API
dotnet run
4. Acesse no navegador
O quêURLFrontend (catálogo)http://localhost:5127Swagger (documentação)http://localhost:5127/swagger
5. Parar tudo
bash# Para a API
Ctrl + C

# Para o MongoDB
docker compose down

📁 Estrutura do projeto
CatalogoLivros/
├── docker-compose.yml          # Sobe o MongoDB
├── README.md
└── CatalogoLivros.API/
    ├── Models/
    │   ├── Autor.cs            # Modelo da entidade Autor
    │   └── Livro.cs            # Modelo da entidade Livro
    ├── Services/
    │   ├── AutorService.cs     # Acesso ao banco — Autor
    │   └── LivroService.cs     # Acesso ao banco — Livro
    ├── Controllers/
    │   ├── AutoresController.cs  # Endpoints REST de /autores
    │   └── LivrosController.cs   # Endpoints REST de /livros
    ├── wwwroot/
    │   └── index.html          # Frontend da aplicação
    ├── appsettings.json        # String de conexão com o banco
    └── Program.cs              # Ponto de entrada da aplicação

🔌 Endpoints da API
Autores
MétodoEndpointDescriçãoGET/autoresLista todos os autoresGET/autores/{id}Busca um autor pelo IDPOST/autoresCadastra um novo autorPUT/autores/{id}Atualiza um autor existenteDELETE/autores/{id}Remove um autor
Livros
MétodoEndpointDescriçãoGET/livrosLista todos os livrosGET/livros/{id}Busca um livro pelo IDPOST/livrosCadastra um novo livroPUT/livros/{id}Atualiza um livro existenteDELETE/livros/{id}Remove um livro

📦 Exemplos de uso
Criar um autor
httpPOST /autores
Content-Type: application/json

{
  "nome": "Machado de Assis",
  "nacionalidade": "Brasileiro",
  "anoNascimento": 1839
}
Resposta 201 Created:
json{
  "id": "6a162f8e46710f2eea13c273",
  "nome": "Machado de Assis",
  "nacionalidade": "Brasileiro",
  "anoNascimento": 1839
}
Criar um livro
httpPOST /livros
Content-Type: application/json

{
  "titulo": "Dom Casmurro",
  "genero": "Romance",
  "anoPublicacao": 1899,
  "sinopse": "Clássico da literatura brasileira",
  "autorId": "6a162f8e46710f2eea13c273"
}

⚙️ Configuração
A string de conexão com o MongoDB fica em appsettings.json:
json{
  "MongoDB": {
    "ConnectionString": "mongodb://admin:senha123@localhost:27017",
    "DatabaseName": "CatalogoLivros"
  }
}

Atenção: nunca exponha credenciais reais no repositório. Em produção, utilize variáveis de ambiente.


👤 Autor
Rayan Gonçalves — Trabalho Prático Semestral — Arquitetura de Aplicações Web 2026.1
