using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseRegistrarEstudanteJson
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Turma Turma { get; set; }
    public string NomeResponsavel { get; set; } = string.Empty;
}
