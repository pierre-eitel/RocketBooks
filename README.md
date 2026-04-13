# RocketBooks API

API REST para gerenciamento de livros desenvolvida em ASP.NET Core.

## Funcionalidades

* Criar livro
* Listar livros
* Buscar livro por ID
* Atualizar livro
* Deletar livro

## Tecnologias

* .NET 8
* ASP.NET Core Web API
* Swagger

## Pré-requisitos

* .NET 8 SDK instalado

## Como rodar o projeto

```bash id="c1run1"
git clone https://github.com/pierre-eitel/RocketBooks.git
cd RocketBooks
dotnet run
```

A API estará disponível em:
https://localhost:5001/swagger

## Regras de negócio

* Não permite livros duplicados (título e autor)
* O preço deve ser maior que zero
* O estoque não pode ser negativo
* O gênero deve ser válido

## Endpoints

| Método | Rota           | Descrição       |
| ------ | -------------- | --------------- |
| POST   | /api/book      | Criar livro     |
| GET    | /api/book      | Listar livros   |
| GET    | /api/book/{id} | Buscar por ID   |
| PUT    | /api/book/{id} | Atualizar livro |
| DELETE | /api/book/{id} | Deletar livro   |

## Exemplo de requisição

### Criar livro

```json id="req1"
{
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "genre": "NonFiction",
  "price": 99.9,
  "stock": 10
}
```

## Exemplo de resposta

```json id="res1"
{
  "id": 1,
  "title": "Clean Code",
  "author": "Robert C. Martin",
  "genre": "NonFiction",
  "price": 99.9,
  "stock": 10
}
```

## Autor
Pierre Eitel Muller Reis
