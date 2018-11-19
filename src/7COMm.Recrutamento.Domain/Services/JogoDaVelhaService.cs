using _7COMm.Recrutamento.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace _7COMm.Recrutamento.Domain.Services
{
    public class JogoDaVelhaService : IJogoDaVelhaService
    {
        public JogoDaVelhaService()
        {
        }

        public bool VerificarResultado(string[] tabuleiro)
        {
            return Vencedor(tabuleiro);
        }

        private bool Vencedor(string[] tabuleiro)
        {
            bool result = false;
            if ((tabuleiro == null) || (tabuleiro.Length != 9))
                return false;
            List<int[]> padroesVitoria = new List<int[]>(){
                    new int[]{0, 1, 2},
                    new int[]{0, 4, 8},
                    new int[]{0, 3, 6},
                    new int[]{1, 4, 7},
                    new int[]{2, 5, 8},
                    new int[]{2, 4, 6},
                    new int[]{3, 4, 5},
                    new int[]{6, 7, 8}
            };
            foreach (int[] padraoVitoria in padroesVitoria)
            {
                result = tabuleiro[padraoVitoria[0]] != null
                  && tabuleiro[padraoVitoria[0]].Equals(tabuleiro[padraoVitoria[1]])
                  && tabuleiro[padraoVitoria[0]].Equals(tabuleiro[padraoVitoria[2]]);
                if (result) break;
            }
            return result;
        }

    }
}
