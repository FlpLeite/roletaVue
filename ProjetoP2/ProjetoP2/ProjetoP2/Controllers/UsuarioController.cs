using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.Contexto;
using ProjetoP2.Models;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLogin usuarioLogin)
        {
            if (string.IsNullOrEmpty(usuarioLogin.Email) || string.IsNullOrEmpty(usuarioLogin.Senha))
            {
                return BadRequest(new { message = "Email e senha são obrigatórios." });
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == usuarioLogin.Email && u.Senha == usuarioLogin.Senha);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Credenciais inválidas." });
            }

            return Ok(new { message = "Login efetuado com sucesso!" });
        }


    }
}
