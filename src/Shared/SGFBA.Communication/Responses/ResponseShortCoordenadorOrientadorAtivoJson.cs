using SGFBA.Communication.Entities;

namespace SGFBA.Communication.Responses;

public class ResponseShortCoordenadorOrientadorAtivoJson
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public IList<Ficha> Fichas { get; set; } = [];
}
