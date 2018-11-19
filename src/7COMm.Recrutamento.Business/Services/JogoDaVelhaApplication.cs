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
    public class JogoDaVelhaApplication : IJogoDaVelha
    {
        private readonly IJogoDaVelhaService _jogoDaVelhaService;
        public JogoDaVelhaApplication(IJogoDaVelhaService jogoDaVelhaService)
        {
            _jogoDaVelhaService = jogoDaVelhaService;
        }

        public ApplicationResponse<TemVencedorResponse> VerificaQuantidadeOcorrencia(TemVencedorRequest request)
        {
            try
            {
                return new ApplicationResponse<TemVencedorResponse>(
                    new TemVencedorResponse()
                    {
                        TemVencedor = _jogoDaVelhaService.VerificarResultado(request.Jogo),
                    },
                    ApplicationResponseStatus.Success,
                    "Sucesso ao verificar se tem ganhador no jogo da velha"
                );
            }
            catch (Exception ex)
            {
                return new ApplicationResponse<TemVencedorResponse>(
                    null,
                    ApplicationResponseStatus.Error,
                    "Erro ao verificar se tem ganhador no jogo da velha"
                );
            }
        }
    }
}
