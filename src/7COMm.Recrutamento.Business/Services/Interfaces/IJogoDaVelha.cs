using _7COMm.Recrutamento.CrossCuting.DTO;
using _7COMm.Recrutamento.CrossCuting.Response;
using System.Collections.Generic;

namespace _7COMm.Recrutamento.Business.Services.Interfaces
{
    public interface IJogoDaVelha
    {
        ApplicationResponse<TemVencedorResponse> VerificarResultado(TemVencedorRequest request);
    }
}
