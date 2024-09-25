using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.Contexto;
using ProjetoP2.Models;
using System.Linq;
using System.Collections.Generic;

namespace ProjetoP2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly RoletaContextMySQL _context;

        public UsuarioController(RoletaContextMySQL context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return NoContent();
        }

        // Método de login utilizando LoginRequest
        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            // Verifica se o email e senha foram fornecidos
            if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Senha))
            {
                return BadRequest(new { message = "Email e senha são obrigatórios." });
            }

            // Busca o usuário no banco de dados
            var user = _context.Usuarios
                .FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                // Verifique se encontrou o email
                return Unauthorized(new { message = "Email não encontrado." });
            }

            // Verifica a senha separadamente para depuração
            if (user.Senha != request.Senha)
            {
                return Unauthorized(new { message = "Senha incorreta." });
            }

            // Sucesso no login
            return Ok(new { message = "Login bem-sucedido", user });
        }
    }
}
