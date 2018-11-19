using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using _7COMm.Recrutamento.Application.Controllers.Bases;
using _7COMm.Recrutamento.CrossCuting.Response;
using _7COMm.Recrutamento.Business.Services.Interfaces;
using _7COMm.Recrutamento.CrossCuting.DTO;

namespace _7COMm.Recrutamento.Application.Controllers
{
    /// <summary>
    /// API de métodos para avaliação de candidato em recrutamento
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/recrutamento")]
    [ApiController]
    public class RecrutamentoController : BaseApiController
    {
        #region Services
        private readonly IContato _contatoApplication;
        private readonly IOcorrencia _ocorrenciaApplication;
        private readonly IJogoDaVelha _jogoDaVelhaApplication;
        #endregion

        public RecrutamentoController(IContato contatoApplication, IOcorrencia ocorrenciaApplication, IJogoDaVelha jogoDaVelhaApplication)
        {
            _contatoApplication = contatoApplication;
            _ocorrenciaApplication = ocorrenciaApplication;
            _jogoDaVelhaApplication = jogoDaVelhaApplication;
        }


        [HttpGet("lista-contatos")]
        public async Task<ApplicationResponse<IEnumerable<string>>> ListarContatos()
        {
            return this.RequestService<ApplicationResponse<IEnumerable<string>>>(() =>
            {
                return _contatoApplication.ListarContatos();
            });
        }

        /// <summary>
        /// Ordenação de lista de string
        /// </summary>
        /// <param name="request">Requisição com a lista a ser ordenada</param>
        /// <response code="200">Lista ordenada</response>
        [HttpPost("ordena-lista")]
        public async Task<ApplicationResponse<OrdenaListaResponse>> OrdenaLista([FromBody] OrdenaListaRequest request)
        {
            return this.RequestService<ApplicationResponse<OrdenaListaResponse>>(() =>
            {
                var outList = _contatoApplication.OrdenarListarContatos(request.Lista);
                return new ApplicationResponse<OrdenaListaResponse>(new OrdenaListaResponse() { ListaOrdenada = outList.Value.ToArray() }, outList.Status, outList.Message);
            });
        }

        /// <summary>
        /// Paginação de lista de string
        /// </summary>
        /// <param name="request">Requisição com o tamanho da página, índice da página e lista a ser paginada</param>
        /// <response code="200">Lista de itens da página solicitada</response>
        [HttpPost("pagina-lista")]
        public async Task<ApplicationResponse<PaginaListaResponse>> PaginaLista([FromBody] PaginaListaRequest request)
        {
            return this.RequestService<ApplicationResponse<PaginaListaResponse>>(() =>
            {
                return _contatoApplication.PaginarLista(request);
            });
        }

        /// <summary>
        /// Busca contato em lista
        /// </summary>
        /// <param name="request">Quantidade de contatos a serem considerados, termo de busca e lista de contatos</param>
        /// <response code="200">Lista de contatos encontrados pela busca ao termo</response>
        [HttpPost("busca-contato-lista")]
        public async Task<ApplicationResponse<BuscaContatoResponse>> BuscaContato([FromBody] BuscaContatoRequest request)
        {
            return this.RequestService<ApplicationResponse<BuscaContatoResponse>>(() =>
            {
                return _contatoApplication.BuscaContato(request);
            });
        }


        //ActionResult
        /// <summary>
        /// Conta ocorrências de uma palavra em um texto
        /// </summary>
        /// <param name="request">Texto e palavra a ser contada</param>
        /// <response code="200">Quantidade de palavras encontradas no texto fornecido</response>
        [HttpPost("quantidade-palavras")]
        public async Task<ApplicationResponse<ContaPalavrasTextoResponse>> ContaPalavrasTexto([FromBody] ContaPalavrasTextoRequest request)
        {
            return this.RequestService<ApplicationResponse<ContaPalavrasTextoResponse>>(() =>
            {
                return _ocorrenciaApplication.ContaPalavrasTexto(request);
            });
        }

        /// <summary>
        /// Verifica se o jogo-da-velha tem vencedor
        /// </summary>
        /// <param name="request">Jogo-da-velha</param>
        /// <response code="200">Jogo tem vencedor</response>
        [HttpPost("tem-vencedor")]
        public async Task<ApplicationResponse<TemVencedorResponse>> TemVencedor([FromBody] TemVencedorRequest request)
        {
            return this.RequestService<ApplicationResponse<TemVencedorResponse>>(() =>
            {
                return _jogoDaVelhaApplication.VerificaQuantidadeOcorrencia(request);
            });
        }
    }
}
