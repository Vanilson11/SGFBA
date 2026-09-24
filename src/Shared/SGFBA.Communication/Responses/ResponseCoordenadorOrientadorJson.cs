using SGFBA.Communication.Entities;
using SGFBA.Communication.Enums;

namespace SGFBA.Communication.Responses;

public class ResponseCoordenadorOrientadorJson
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public CargoUsuario Cargo { get; set; }
    public string Role { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public IList<Ficha> Fichas { get; set; } = [];
}
