using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using _7COMm.Recrutamento.Application.WebUI.Constants;
using _7COMm.Recrutamento.Application.WebUI.Pages.Bases;
using _7COMm.Recrutamento.Application.WebUI.PagesModels;
using _7COMm.Recrutamento.CrossCuting.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using _7COMm.Recrutamento.CrossCuting.Helpers.States;
using _7COMm.Recrutamento.CrossCuting.DTO;
using System;

namespace _7COMm.Recrutamento.Application.WebUI.Pages
{
    public partial class ContatosModel : BasePageModel
    {
        #region Props
        private const string ViewDataContatos = "SessionContatos";

        [BindProperty]
        public ContatosPageModel Contatos { get; set; }
        #endregion
        public ContatosModel(IConfiguration configuration, RequestHandler requestHandler) : base(configuration, requestHandler)
        {
            Contatos = new ContatosPageModel() { ListaContatos = new PaginaListaResponse() { TotalPages = 3, PageIndex = 1 } };
        }

        public void OnGet(string ordem,
            string filtroAtual,
            string filtro,
            int? qtdVisual,
            int? pagina)
        {

            bool filtrar = (filtro != null);

            if (filtrar)
                pagina = 1;
            else
                filtro = filtroAtual;

            if (this.ReturnSessionValue<ContatosPageModel>(ViewDataContatos) == null && string.IsNullOrEmpty(filtro))
                this.ListarContatos();
            else
            {
                Contatos = this.ReturnSessionValue<ContatosPageModel>(ViewDataContatos);
                Contatos.ListaContatos.ListaPaginada = Contatos.ListaOriginal;
                Contatos.ListaContatos.PageIndex = pagina.HasValue ? pagina.Value : 1;
                Contatos.ListaContatos.TotalPages = (qtdVisual != null) ? qtdVisual.Value : int.Parse(this._configuration.GetSection("AppSetings")["TotalPorPagina"]);

                if (filtrar)
                    this.BuscarContato(filtro);
                else
                    this.PaginarLista();

            }
            ViewData["ordemAtual"] = ordem;
            ViewData["NomeParm"] = String.IsNullOrEmpty(ordem) ? "Nome" : "";
            ViewData["DataParm"] = ordem == "Nome" ? "Nome" : "Tefone";
            ViewData["filtroAtual"] = filtro;
            ViewData["qtdVisual"] = qtdVisual;
        }


        private void ListarContatos()
        {
            var responseListarContatos = IntegrationAPI.InvokeObject<ApplicationResponse<string[]>>(
                ConstContato.UrlListarContatos,
                HttpMethod.Get
                );
            if (responseListarContatos.Status == ApplicationResponseStatus.Success)
            {
                Contatos.ListaContatos.ListaPaginada = responseListarContatos.Value;
                OrdenarLista();
            }
        }

        private void OrdenarLista()
        {
            var responseListarContatosOrdenada = IntegrationAPI.InvokeObject<ApplicationResponse<OrdenaListaResponse>, OrdenaListaRequest>(
               ConstContato.UrlOrdenarLista,
               HttpMethod.Post,
               new OrdenaListaRequest() { Lista = Contatos.ListaContatos.ListaPaginada.ToArray() }
               );
            if (responseListarContatosOrdenada.Status == ApplicationResponseStatus.Success)
            {
                Contatos.ListaContatos.ListaPaginada = responseListarContatosOrdenada.Value.ListaOrdenada;
                Contatos.ListaOriginal = Contatos.ListaContatos.ListaPaginada;
                PaginarLista();
            }
        }

        private void PaginarLista()
        {
            var sourcePaginarListaBefore = Contatos;
            var sourcePaginarListaAfter = new PaginaListaRequest()
            {
                Lista = sourcePaginarListaBefore.ListaContatos.ListaPaginada,
                IndicePagina = sourcePaginarListaBefore.ListaContatos.PageIndex,
                TamanhoPagina = sourcePaginarListaBefore.ListaContatos.TotalPages
            };

            var responseListarPaginada = IntegrationAPI.InvokeObject<ApplicationResponse<PaginaListaResponse>, PaginaListaRequest>(
              ConstContato.UrlPaginarLista,
              HttpMethod.Post,
              sourcePaginarListaAfter
              );
            if (responseListarPaginada.Status == ApplicationResponseStatus.Success)
            {
                var listPaginada = responseListarPaginada.Value;
                Contatos.ListaContatos.ListaPaginada = listPaginada.ListaPaginada;
                Contatos.ListaContatos.PageIndex = listPaginada.PageIndex;
                Contatos.ListaContatos.TotalPages = listPaginada.TotalPages;
                this.SaveInSession<ContatosPageModel>(Contatos, ViewDataContatos);
            }
        }


        private void BuscarContato(string termo)
        {
            var responseBusca = IntegrationAPI.InvokeObject<ApplicationResponse<BuscaContatoResponse>, BuscaContatoRequest>(
             ConstContato.UrlBuscarContato,
             HttpMethod.Post,
             new BuscaContatoRequest() { Busca = termo, QuantidadeRegistro = Contatos.ListaContatos.TotalPages }
             );
            if (responseBusca.Status == ApplicationResponseStatus.Success)
            {
                var resultBusca = responseBusca.Value;
                Contatos.ListaContatos.ListaPaginada = resultBusca.ListaContatos.Select(item => item.Nome).ToArray();
                Contatos.ListaContatos.PageIndex = 1;
                this.SaveInSession<ContatosPageModel>(Contatos, ViewDataContatos);
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}