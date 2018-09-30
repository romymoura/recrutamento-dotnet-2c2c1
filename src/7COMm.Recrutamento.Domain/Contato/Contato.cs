namespace _7COMm.Recrutamento.Domain.Contato
{
    public class Contato : IContato
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public bool Equals(IContato other)
        {
            return Nome.Equals(other.Nome) && Telefone.Equals(other.Telefone);
        }
    }
}
