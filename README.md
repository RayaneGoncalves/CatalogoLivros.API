# 📚 Catálogo de Livros

API REST para gerenciamento de um catálogo pessoal de livros, desenvolvida com **.NET 10**, **C#** e **MongoDB**. Permite cadastrar autores e livros, editar informações e excluir registros através de uma interface web com navegação assíncrona.

> 🎓 Trabalho Prático — Arquitetura de Aplicações Web 2026.1 — Rayan Gonçalves

---

## 🛠️ Tecnologias

- **Backend:** .NET 10 com C# — Web API
- **Banco de dados:** MongoDB 7 (via Docker)
- **Documentação:** Swagger / OpenAPI
- **Frontend:** HTML + JavaScript (Fetch API)
- **Containerização:** Docker + Docker Compose

---

## ✅ Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) instalado e rodando

---

## 🚀 Como executar

**1. Clone o repositório**

```bash
git clone https://github.com/seu-usuario/CatalogoLivros.git
cd CatalogoLivros
```

**2. Suba o MongoDB com Docker**

```bash
docker compose up -d
docker ps   # catalogo-mongo deve aparecer com status Up
```

**3. Rode a API**

```bash
cd CatalogoLivros.API
dotnet run
```

**4. Acesse no navegador**

- 🌐 Frontend: [http://localhost:5127](http://localhost:5127)
- 📄 Swagger: [http://localhost:5127/swagger](http://localhost:5127/swagger)

**5. Parar tudo**

```bash
Ctrl + C            # para a API
docker compose down # para o MongoDB
```

---

## 📁 Estrutura do projeto

```
CatalogoLivros/
├── docker-compose.yml
├── README.md
└── CatalogoLivros.API/
    ├── Models/
    │   ├── Autor.cs
    │   └── Livro.cs
    ├── Services/
    │   ├── AutorService.cs
    │   └── LivroService.cs
    ├── Controllers/
    │   ├── AutoresController.cs
    │   └── LivrosController.cs
    ├── wwwroot/
    │   └── index.html
    ├── appsettings.json
    └── Program.cs
```

---

## 🔌 Endpoints da API

### Autores — `/autores`

| Método | Rota | Descrição |
|--------|------|-----------|
| `GET` | `/autores` | Lista todos os autores |
| `GET` | `/autores/{id}` | Busca um autor pelo ID |
| `POST` | `/autores` | Cadastra um novo autor |
| `PUT` | `/autores/{id}` | Atualiza um autor existente |
| `DELETE` | `/autores/{id}` | Remove um autor |

### Livros — `/livros`

| Método | Rota | Descrição |
|--------|------|-----------|
| `GET` | `/livros` | Lista todos os livros |
| `GET` | `/livros/{id}` | Busca um livro pelo ID |
| `POST` | `/livros` | Cadastra um novo livro |
| `PUT` | `/livros/{id}` | Atualiza um livro existente |
| `DELETE` | `/livros/{id}` | Remove um livro |

---

## 📦 Exemplos de uso

### Criar um autor — `POST /autores`

```json
{
  "nome": "Machado de Assis",
  "nacionalidade": "Brasileiro",
  "anoNascimento": 1839
}
```

Resposta `201 Created`:

```json
{
  "id": "6a162f8e46710f2eea13c273",
  "nome": "Machado de Assis",
  "nacionalidade": "Brasileiro",
  "anoNascimento": 1839
}
```

### Criar um livro — `POST /livros`

```json
{
  "titulo": "Dom Casmurro",
  "genero": "Romance",
  "anoPublicacao": 1899,
  "sinopse": "Clássico da literatura brasileira",
  "autorId": "6a162f8e46710f2eea13c273"
}
```

---

## ⚙️ Configuração

A string de conexão com o MongoDB fica em `appsettings.json`:

```json
{
  "MongoDB": {
    "ConnectionString": "mongodb://admin:senha123@localhost:27017",
    "DatabaseName": "CatalogoLivros"
  }
}
```


