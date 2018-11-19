using _7COMm.Recrutamento.Domain.Entities;
using _7COMm.Recrutamento.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace _7COMm.Recrutamento.Domain.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IEnumerable<Contato> BuscaContato(int quantidade, string termoBusca)
        {
            return _contatoRepository.BuscaContato(quantidade, termoBusca);
        }

        public Contato Create(Contato contato)
        {
            return _contatoRepository.Create(contato);
        }

        public IEnumerable<string> ListarContatos()
        {
            return _contatoRepository.ListarContatos();
        }

        public IEnumerable<string> OrdenarListarContatos(IEnumerable<string> lista)
        {
            return lista.ToList<string>().OrderBy((item) => item);
        }

        public IEnumerable<string> PaginarLista(IEnumerable<string> source, int tamanhoPagina, int indicePagina)
        {
            return source.Skip((indicePagina - 1) * tamanhoPagina).Take(tamanhoPagina).ToList();
        }
    }
}
