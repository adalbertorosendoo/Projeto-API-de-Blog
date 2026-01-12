# Blog API

API REST simples desenvolvida em ASP.NET Core para gerenciamento de posts de blog e seus comentários associados.  
Este projeto foi criado como parte de um desafio técnico, com foco em simplicidade, clareza e organização do código.

---

## Tecnologias Utilizadas

- C#
- ASP.NET Core Web API (.NET 7 / .NET 8)
- Swagger (OpenAPI)

---

## Descrição do Projeto

A Blog API permite:

- Criar posts de blog
- Listar todos os posts com a quantidade de comentários
- Buscar um post específico pelo ID
- Adicionar comentários a um post específico

Para manter o projeto simples e dentro do escopo do desafio, os dados são armazenados **em memória**, sem utilização de banco de dados.

---

## Como Executar o Projeto

### Pré-requisitos

- .NET SDK 7 ou superior
- Visual Studio 2022 (ou IDE compatível)

### Passos para execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/adalbertorosendoo/Projeto-API-de-Blog.git

2. Abra a solução no Visual Studio 2022
3. Execute o projeto pressionando F5 ou clicando em Run
4. Após a aplicação iniciar, acesse o Swagger pelo navegador:
   ```bash
   https://localhost:xxxx/swagger

# Endpoints da API

## GET /api/posts

- Retorna todos os posts do blog, incluindo a quantidade de comentários de cada post.
- Exemplo de resposta:

[
  {
    "id": 1,
    "titulo": "Meu primeiro post",
    "conteudo": "Conteúdo do post",
    "numeroComentarios": 2
  }
]

---

## POST /api/posts

- Cria um novo post de blog.
- Exemplo de requisição (JSON):

{
  "titulo": "Meu primeiro post",
  "conteudo": "Esse é o conteúdo do meu post"
}

---

## GET /api/posts/{id}

- Retorna um post específico pelo ID, incluindo seus comentários.
- Exemplo de resposta:

{
  "id": 1,
  "titulo": "Meu primeiro post",
  "conteudo": "Esse é o conteúdo do meu post",
  "comentarios": [
    {
      "id": 1,
      "texto": "Gostei bastante!",
      "dataCriacao": "2026-01-01T12:00:00Z"
    }
  ]
}

---

## POST /api/posts/{id}/comments

- Adiciona um comentário a um post existente.
- Exemplo de requisição (JSON):

{
  "texto": "Gostei muito desse post!"
}

---

# Observações Técnicas

- Os dados são armazenados apenas em memória.
- Ao reiniciar a aplicação, todos os dados são perdidos.
- Essa abordagem foi adotada para manter o projeto simples e alinhado ao escopo do desafio técnico.
