using BlogApi.DTOs;
using BlogApi.Models;
using BlogApi.Models.BlogApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private static readonly List<BlogPost> Posts = new();
        private static int _postId = 1;
        private static int _commentId = 1;

        // GET /api/posts
        [HttpGet]
        public IActionResult GetPosts()
        {
            var result = Posts.Select(p => new
            {
                p.Id,
                p.Titulo,
                p.Conteudo,
                NumeroComentarios = p.Comentarios.Count
            });

            return Ok(result);
        }

        // POST /api/posts
        [HttpPost]
        public IActionResult CreatePost(CreatePostDto dto)
        {
            var post = new BlogPost
            {
                Id = _postId++,
                Titulo = dto.Titulo,
                Conteudo = dto.Conteudo
            };

            Posts.Add(post);

            return CreatedAtAction(nameof(GetPostById), new { id = post.Id }, post);
        }

        // GET /api/posts/{id}
        [HttpGet("{id}")]
        public IActionResult GetPostById(int id)
        {
            var post = Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        // POST /api/posts/{id}/comments
        [HttpPost("{id}/comments")]
        public IActionResult AddComment(int id, CreateCommentDto dto)
        {
            var post = Posts.FirstOrDefault(p => p.Id == id);

            if (post == null)
                return NotFound();

            var comment = new Comment
            {
                Id = _commentId++,
                Texto = dto.Texto
            };

            post.Comentarios.Add(comment);

            return Ok(comment);
        }
    }
}
