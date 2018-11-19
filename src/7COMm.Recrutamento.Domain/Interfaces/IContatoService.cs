using _7COMm.Recrutamento.Domain.Entities;
using System.Collections.Generic;

namespace _7COMm.Recrutamento.Domain.Interfaces
{
    public interface IContatoService
    {
        Contato Create(Contato contato);
        IEnumerable<string> ListarContatos();
        IEnumerable<string> OrdenarListarContatos(IEnumerable<string> lista);
        IEnumerable<string> PaginarLista(IEnumerable<string> source, int tamanhoPagina, int indicePagina);
        IEnumerable<Contato> BuscaContato(int quantidade, string termoBusca);
    }
}
