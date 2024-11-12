using ProjetoP2.Models;

namespace ProjetoP2.ServicesInterface
{
    public interface ITokenService
    {
        string CreateCustomerToken(Usuario usuario);
    }
}
