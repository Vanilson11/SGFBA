namespace SGFBA.Communication.Requests;

public class RequestAlterarSenhaJson
{
    public string SenhaAtual { get; set; } = string.Empty;
    public string NovaSenha { get; set; } = string.Empty;
}
