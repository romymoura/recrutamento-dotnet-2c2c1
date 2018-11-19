using _7COMm.Recrutamento.Domain.Entities;
using _7COMm.Recrutamento.Domain.Interfaces;
namespace _7COMm.Recrutamento.CrossCuting.DTO
{
    public class BuscaContatoResponse
    {
        public Contato[] ListaContatos { get; set; }
    }
}
