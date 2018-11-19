using _7COMm.Recrutamento.Application.WebUI.Data;
using _7COMm.Recrutamento.Domain.Entities;
using _7COMm.Recrutamento.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace _7COMm.Recrutamento.Data.EntityObjectsRepositorys
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Contato Create(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }
        public IEnumerable<Contato> BuscaContato(int quantidade, string termoBusca)
        {
            return _context.Contatos.Where(item => item.Nome.Contains(termoBusca)).Take(quantidade).ToArray();
        }

        public IEnumerable<string> ListarContatos()
        {
            return _context.Contatos.Select(item => item.Nome).ToList();
        }

    }
}