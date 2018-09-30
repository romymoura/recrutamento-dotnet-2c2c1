using System;

namespace _7COMm.Recrutamento.Domain.Contato
{
    public interface IContato : IEquatable<IContato>
    {
        string Nome { get; set; }
        string Telefone { get; set; }
    }
}
