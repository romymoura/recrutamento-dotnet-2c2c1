using System;
using System.Collections.Generic;
using System.Text;

namespace _7COMm.Recrutamento.Domain.Contato
{
    public class ContatoFactory
    {
        public IContato Create()
        {
            return new Contato();
        }

        public IContato Create(string nome, string telefone)
        {
            return new Contato { Nome = nome, Telefone = telefone };
        }
    }
}
