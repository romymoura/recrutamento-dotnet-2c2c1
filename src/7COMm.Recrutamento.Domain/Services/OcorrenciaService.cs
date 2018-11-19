using _7COMm.Recrutamento.Domain.Entities;
using _7COMm.Recrutamento.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _7COMm.Recrutamento.Domain.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        public OcorrenciaService()
        {
        }
        public int VerificaQuantidadeOcorrencia(string texto, string termo)
        {
            return texto.ToUpper().Split(' ').Where(item => item.Contains(termo.ToUpper())).ToList().Count();
        }
    }
}
