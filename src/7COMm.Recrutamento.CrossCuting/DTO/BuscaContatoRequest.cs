using _7COMm.Recrutamento.Domain.Entities;
namespace _7COMm.Recrutamento.CrossCuting.DTO
{
    public class BuscaContatoRequest
    {
        public int QuantidadeRegistro { get; set; }
        public string Busca { get; set; }
        public Contato[] ListaContatos { get; set; }
    }
}
