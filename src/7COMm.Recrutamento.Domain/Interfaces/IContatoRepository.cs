using _7COMm.Recrutamento.Domain.Entities;
using System.Collections.Generic;

namespace _7COMm.Recrutamento.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Contato Create(Contato contato);
        IEnumerable<string> ListarContatos();
        IEnumerable<Contato> BuscaContato(int quantidade, string termoBusca);
    }
}
