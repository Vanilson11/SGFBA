using Mapster;
using SGFBA.Communication.Requests;
using SGFBA.Communication.Responses;
using SGFBA.Domain.Entities;
using SGFBA.Domain.Repositories;
using SGFBA.Domain.Repositories.Fichas;
using SGFBA.Exception.ExceptionsBase;

namespace SGFBA.Application.UseCases.Fichas.Registrar;

public class RegistrarFichaUseCase : IRegistrarFichaUseCase
{
    private readonly IWriteOnlyFichasRepository _writeOnlyFichasRepository;
    private readonly IUnitOffWork _unitOffWork;

    public RegistrarFichaUseCase(
        IWriteOnlyFichasRepository writeOnlyFichasRepository,
        IUnitOffWork unitOffWork
        )
    {
        _writeOnlyFichasRepository = writeOnlyFichasRepository;
        _unitOffWork = unitOffWork;
    }
    public async Task<ResponseRegistrarFichaJson> Executar(RequestRegistrarFichaJson request)
    {
        Validar_Request(request);

        var ficha = request.Adapt<Ficha>();
        //buscar estudante
        //associar estudante à ficha
        //associar coordenador/orientador à ficha

        await _writeOnlyFichasRepository.Adicionar(ficha);

        await _unitOffWork.Commit();

        return new ResponseRegistrarFichaJson
        {
            Id = 1,
            DataAbertura = request.DataAbertura,
            Status = request.Status
        };
    }

    private void Validar_Request(RequestRegistrarFichaJson request)
    {
        var resultado = new FichaValidator().Validate(request);

        if(resultado.IsValid is false)
        {
            var mensagensErro = resultado.Errors.Select(erro => erro.ErrorMessage).ToList();

            throw new ErrosNaValidacaoException(mensagensErro);
        }
    }
}
