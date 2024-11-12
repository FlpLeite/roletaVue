using ProjetoP2.Models;
using ProjetoP2.Contexto;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.ServicesInterface;

namespace ProjetoP2.Services
{
    public class AuthService : IAuthService
    {
        private readonly RoletaContextMySQL _context;
        private readonly ITokenService _tokenService;

        public AuthService(RoletaContextMySQL context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> SignIn(string email, string password)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == password);

            if (usuario == null)
            {
                throw new Exception("E-mail e/ou senha inválidos");
            }

            string token = _tokenService.CreateCustomerToken(usuario);
            return token;
        }

        public string GetAuthenticatedUserId(ClaimsPrincipal user)
        {
            return user.FindFirst("id")?.Value;
        }
    }
}
