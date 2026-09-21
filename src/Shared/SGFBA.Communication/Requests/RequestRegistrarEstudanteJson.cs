using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Requests;

public class RequestRegistrarEstudanteJson
{
    public string Nome { get; set; } = string.Empty;
    public Turma Turma { get; set; }
    public Turno Turno { get; set; }
    public DateTime DataNascimento { get; set; }
    public string NomeResponsavel { get; set; } = string.Empty;
    public string TelefoneResponsavel { get; set; } = string.Empty;
}
