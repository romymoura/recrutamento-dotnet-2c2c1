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
    public class ContatoApplication : IContato
    {
        private readonly IContatoService _contatoService;
        public ContatoApplication(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public ApplicationResponse<IEnumerable<string>> ListarContatos()
        {
            try
            {
                return new ApplicationResponse<IEnumerable<string>>(
                    _contatoService.ListarContatos(),
                    ApplicationResponseStatus.Success,
                    "Sucesso ao listar os contatos"
                );
            }
            catch (Exception ex)
            {
                return new ApplicationResponse<IEnumerable<string>>(
                   null,
                   ApplicationResponseStatus.Error, "Erro ao listar os contatos"
               );
            }
        }

        public ApplicationResponse<IEnumerable<string>> OrdenarListarContatos(IEnumerable<string> lista)
        {
            try
            {
                return new ApplicationResponse<IEnumerable<string>>(
                    _contatoService.OrdenarListarContatos(lista),
                    ApplicationResponseStatus.Success,
                    "Sucesso ao ordenar a listagem"
                );
            }
            catch (Exception ex)
            {
                return new ApplicationResponse<IEnumerable<string>>(
                   null,
                   ApplicationResponseStatus.Error, "Erro ao ordenar a listagem"
               );
            }

        }

        public ApplicationResponse<PaginaListaResponse> PaginarLista(PaginaListaRequest sourcePaginar)
        {
            try
            {
                var count = sourcePaginar.Lista.Count();
                PaginaListaResponse responseListaPaginada = new PaginaListaResponse()
                {
                    ListaPaginada = _contatoService.PaginarLista(sourcePaginar.Lista, sourcePaginar.TamanhoPagina, sourcePaginar.IndicePagina).ToArray(),
                    PageIndex = sourcePaginar.IndicePagina,
                    TotalPages = (int)Math.Ceiling(count / (double)sourcePaginar.TamanhoPagina)
                };
                return new ApplicationResponse<PaginaListaResponse>(
                    responseListaPaginada,
                    ApplicationResponseStatus.Success,
                    "Sucesso na paginação"
                );
            }
            catch (Exception ex)
            {
                return new ApplicationResponse<PaginaListaResponse>(
                   null,
                   ApplicationResponseStatus.Error, "Erro na paginação"
               );
            }
        }

        public ApplicationResponse<BuscaContatoResponse> BuscaContato(BuscaContatoRequest request)
        {
            try
            {
                return new ApplicationResponse<BuscaContatoResponse>(new BuscaContatoResponse()
                {
                    ListaContatos = _contatoService.BuscaContato(request.QuantidadeRegistro, request.Busca).ToArray()
                }, ApplicationResponseStatus.Success, "Sucesso na busca de contatos");
            }
            catch (Exception ex)
            {
                return new ApplicationResponse<BuscaContatoResponse>(
                   null,
                   ApplicationResponseStatus.Error, "Erro na busca de contatos"
               );
            }
        }
    }
}
