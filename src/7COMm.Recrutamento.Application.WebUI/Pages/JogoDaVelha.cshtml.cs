using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using _7COMm.Recrutamento.Application.WebUI.Constants;
using _7COMm.Recrutamento.Application.WebUI.Pages.Bases;
using _7COMm.Recrutamento.Application.WebUI.PagesModels;
using _7COMm.Recrutamento.CrossCuting.DTO;
using _7COMm.Recrutamento.CrossCuting.Helpers.States;
using _7COMm.Recrutamento.CrossCuting.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace _7COMm.Recrutamento.Application.WebUI.Pages
{
    public class JogoDaVelhaModel : BasePageModel
    {
        private const string SessionTabuleiro = "Tabuleiro";

        [BindProperty]
        public JogoDaVelhaPageModel Tabuleiro { get; set; }

        public JogoDaVelhaModel(IConfiguration configuration, RequestHandler requestHandler) : base(configuration, requestHandler)
        {
            if (this.ReturnSessionValue<JogoDaVelhaPageModel>(SessionTabuleiro) == null)
                Tabuleiro = new JogoDaVelhaPageModel();
            else
                Tabuleiro = this.ReturnSessionValue<JogoDaVelhaPageModel>(SessionTabuleiro);
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            Tabuleiro.TemVencedor = false;
            if (!ModelState.IsValid)
                return Page();

            var responseListarContatos = IntegrationAPI.InvokeObject<ApplicationResponse<TemVencedorResponse>, TemVencedorRequest>(
              ConstJogoDaVelha.UrlTemVencedor,
              HttpMethod.Post,
              new TemVencedorRequest() { Jogo = Tabuleiro.Velha }
              );
            if (responseListarContatos.Status == ApplicationResponseStatus.Success)
            {
                Tabuleiro.TemVencedor = responseListarContatos.Value.TemVencedor;
                this.SaveInSession<JogoDaVelhaPageModel>(Tabuleiro, SessionTabuleiro);
            }
            return RedirectToPage("/JogoDaVelha");
        }
    }
}