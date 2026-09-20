namespace SGFBA.Domain.Security.Criptography;

public interface IPasswordHasher
{
    string HashPassword(string senha);
    bool VerifyPassword(string senha, string hashedSenha);
}
