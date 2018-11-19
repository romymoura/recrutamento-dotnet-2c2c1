using System.Collections.Generic;

namespace _7COMm.Recrutamento.Application.ActionModel
{
    public class BuscaContatoResponse
    {
        public Domain.Interfaces.IContatoService[] ListaContatos { get; set; }
    }
}
