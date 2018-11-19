using System.Collections.Generic;

namespace _7COMm.Recrutamento.Application.ActionModel
{
    public class BuscaContatoRequest
    {
        public int QuantidadeRegistro { get; set; }
        public string Busca { get; set; }
        public Domain.Entities.Contato[] ListaContatos { get; set; }
    }
}
