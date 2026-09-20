using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Gerar(Usuario usuario);
}
