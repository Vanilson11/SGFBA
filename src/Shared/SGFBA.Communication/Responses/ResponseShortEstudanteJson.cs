using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseShortEstudanteJson
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Turma Turma { get; set; }
    public Turno Turno { get; set; }
    public DateTime DataNascimento { get; set; }
}
