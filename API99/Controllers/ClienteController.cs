using Microsoft.AspNetCore.Mvc;
using API99.Models;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly Padaria2Context _context;

    public ClienteController(Padaria2Context context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetTodos()
    {
        var clientes = _context.Clientes.ToList();
        return Ok(clientes);
    }
}
