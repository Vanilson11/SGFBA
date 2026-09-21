using SGFBA.Domain.Entities;

namespace SGFBA.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<Usuario> Get();
}
