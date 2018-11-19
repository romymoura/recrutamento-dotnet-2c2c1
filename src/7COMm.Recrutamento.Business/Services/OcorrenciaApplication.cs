using _7COMm.Recrutamento.Business.Services.Interfaces;
using _7COMm.Recrutamento.CrossCuting.DTO;
using _7COMm.Recrutamento.CrossCuting.Response;
using _7COMm.Recrutamento.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace _7COMm.Recrutamento.Business.Services
{
    public class OcorrenciaApplication : IOcorrencia
    {
        private readonly IOcorrenciaService _ocorrenciaService;
        public OcorrenciaApplication(IOcorrenciaService ocorrenciaService)
        {
            _ocorrenciaService = ocorrenciaService;
        }

        public ApplicationResponse<ContaPalavrasTextoResponse> ContaPalavrasTexto(ContaPalavrasTextoRequest request)
        {
            try
            {
                return new ApplicationResponse<ContaPalavrasTextoResponse>(
                    new ContaPalavrasTextoResponse()
                    {
                        QuantidadeOcorrencias = _ocorrenciaService.VerificaQuantidadeOcorrencia(request.Texto, request.Palavra),
                    },                  
                    ApplicationResponseStatus.Success,
                    "Sucesso ao verificar a quantidade de ocorrências"
                );
            }
            catch (Exception ex)
            {
                return new ApplicationResponse<ContaPalavrasTextoResponse>(
                    null,
                    ApplicationResponseStatus.Error,
                    "Erro ao verificar a quantidade de ocorrências"
                );
            }
        }
    }
}
