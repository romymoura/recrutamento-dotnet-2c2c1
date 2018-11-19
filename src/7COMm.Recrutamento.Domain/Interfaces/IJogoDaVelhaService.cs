using _7COMm.Recrutamento.Domain.Entities;
using System.Collections.Generic;

namespace _7COMm.Recrutamento.Domain.Interfaces
{
    public interface IJogoDaVelhaService
    {
        bool VerificarResultado(string[] tabuleiro);
    }
}
