using System;
using _7COMm.Recrutamento.Application.ActionModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _7COMm.Recrutamento.Application.Controllers
{
    /// <summary>
    /// API de métodos para avaliação de candidato em recrutamento
    /// </summary>
    [Produces("application/json")]
    [Route("api/v1/recrutamento")]
    [ApiController]
    public class RecrutamentoController : ControllerBase
    {
        /// <summary>
        /// Ordenação de lista de string
        /// </summary>
        /// <param name="request">Requisição com a lista a ser ordenada</param>
        /// <response code="200">Lista ordenada</response>
        [HttpPost("ordena-lista")]
        public async Task<ActionResult<OrdenaListaResponse>> OrdenaLista([FromBody] OrdenaListaRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Paginação de lista de string
        /// </summary>
        /// <param name="request">Requisição com o tamanho da página, índice da página e lista a ser paginada</param>
        /// <response code="200">Lista de itens da página solicitada</response>
        [HttpPost("pagina-lista")]
        public async Task<ActionResult<PaginaListaResponse>> PaginaLista([FromBody] PaginaListaRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Busca contato em lista
        /// </summary>
        /// <param name="request">Quantidade de contatos a serem considerados, termo de busca e lista de contatos</param>
        /// <response code="200">Lista de contatos encontrados pela busca ao termo</response>
        [HttpPost("busca-contato-lista")]
        public async Task<ActionResult<BuscaContatoResponse>> BuscaContato([FromBody] BuscaContatoRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Conta ocorrências de uma palavra em um texto
        /// </summary>
        /// <param name="request">Texto e palavra a ser contada</param>
        /// <response code="200">Quantidade de palavras encontradas no texto fornecido</response>
        [HttpPost("quantidade-palavras")]
        public async Task<ActionResult<ContaPalavrasTextoResponse>> ContaPalavrasTexto([FromBody] ContaPalavrasTextoRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verifica se o jogo-da-velha tem vencedor
        /// </summary>
        /// <param name="request">Jogo-da-velha</param>
        /// <response code="200">Jogo tem vencedor</response>
        [HttpPost("tem-vencedor")]
        public async Task<ActionResult<TemVencedorResponse>> TemVencedor([FromBody] TemVencedorRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
