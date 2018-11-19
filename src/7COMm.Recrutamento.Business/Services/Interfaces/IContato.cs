using _7COMm.Recrutamento.CrossCuting.DTO;
using _7COMm.Recrutamento.CrossCuting.Response;
using System.Collections.Generic;

namespace _7COMm.Recrutamento.Business.Services.Interfaces
{
    public interface IContato
    {
        ApplicationResponse<IEnumerable<string>> ListarContatos();
        ApplicationResponse<IEnumerable<string>> OrdenarListarContatos(IEnumerable<string> lista);
        ApplicationResponse<PaginaListaResponse> PaginarLista(PaginaListaRequest sourcePaginar);
        ApplicationResponse<BuscaContatoResponse> BuscaContato(BuscaContatoRequest request);
    }
}
