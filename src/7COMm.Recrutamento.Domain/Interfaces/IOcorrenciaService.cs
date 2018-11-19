using _7COMm.Recrutamento.Domain.Entities;
using System.Collections.Generic;

namespace _7COMm.Recrutamento.Domain.Interfaces
{
    public interface IOcorrenciaService
    {
        int VerificaQuantidadeOcorrencia(string texto, string termo);
    }
}
