using _7COMm.Recrutamento.CrossCuting.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _7COMm.Recrutamento.Application.WebUI.PagesModels
{
    public class ContatosPageModel
    {
        public string[] ListaOriginal { get; set; }
        public PaginaListaResponse ListaContatos { get; set; }
    }
}
