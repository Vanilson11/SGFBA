using SGFBA.Communication.Entities;

namespace SGFBA.Communication.Responses;

public class ResponseShortCoordenadoresOrientadoresJson
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public IList<Ficha> Fichas { get; set; } = [];
}
