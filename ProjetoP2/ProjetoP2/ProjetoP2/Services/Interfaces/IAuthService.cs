using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoP2.ServicesInterface
{
    public interface IAuthService
    {
        Task<string> SignIn(string email, string password);
        string GetAuthenticatedUserId(ClaimsPrincipal user);
    }
}
