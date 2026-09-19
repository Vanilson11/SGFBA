namespace SGFBA.Communication.Responses;

public class ResponseErrorMessagesJson
{
    public List<string> Erros { get; set; } = [];

    public ResponseErrorMessagesJson(List<string> erros)
    {
        Erros = erros;
    }

    public ResponseErrorMessagesJson(string erro)
    {
        Erros = [erro];
    }
}
