using Microsoft.AspNetCore.Mvc;
using API99.Models; // ← Este é o namespace da classe Livro


namespace API99.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private static List<Livro> Livros = new List<Livro>
        {
            new Livro { Id = 1, Titulo = "O Alquimista", Autor = "Paulo Coelho" },
            new Livro { Id = 2, Titulo = "Dom Casmurro", Autor = "Machado de Assis" }
        };

        [HttpGet]
        public ActionResult<List<Livro>> Get() => Livros;

        [HttpGet("{id}")]
        public ActionResult<Livro> Get(int id)
        {
            var livro = Livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();
            return livro;
        }

        [HttpPost]
        public ActionResult<Livro> Post([FromBody] Livro novoLivro)
        {
            novoLivro.Id = Livros.Max(l => l.Id) + 1;
            Livros.Add(novoLivro);
            return CreatedAtAction(nameof(Get), new { id = novoLivro.Id }, novoLivro);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Livro livroAtualizado)
        {
            var livro = Livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();

            livro.Titulo = livroAtualizado.Titulo;
            livro.Autor = livroAtualizado.Autor;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var livro = Livros.FirstOrDefault(l => l.Id == id);
            if (livro == null)
                return NotFound();

            Livros.Remove(livro);
            return NoContent();
        }
    }
}
