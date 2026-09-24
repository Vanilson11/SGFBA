using SGFBA.Communication.Entities;
using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseEstudanteJson
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public Turma Turma { get; set; }
    public Turno Turno { get; set; }
    public DateTime DataNascimento { get; set; }
    public string NomeResponsavel { get; set; } = string.Empty;
    public string TelefoneResponsavel { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public IList<Ficha> Fichas { get; set; } = [];
}
