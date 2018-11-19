using System.Net.Http;
using System.Threading.Tasks;
using _7COMm.Recrutamento.Application.WebUI.Constants;
using _7COMm.Recrutamento.Application.WebUI.Pages.Bases;
using _7COMm.Recrutamento.Application.WebUI.PagesModels;
using _7COMm.Recrutamento.CrossCuting.DTO;
using _7COMm.Recrutamento.CrossCuting.Helpers.States;
using _7COMm.Recrutamento.CrossCuting.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace _7COMm.Recrutamento.Application.WebUI.Pages
{
    public class OcorrenciasTermoModel : BasePageModel
    {
        private const string SessionModel = "OcorrenciaPageModel";

        [BindProperty]
        public OcorrenciaPageModel Ocorrencia { get; set; }
        public OcorrenciasTermoModel(IConfiguration configuration, RequestHandler requestHandler) : base(configuration, requestHandler)
        {
            if (this.ReturnSessionValue<OcorrenciaPageModel>(SessionModel) == null)
                Ocorrencia = new OcorrenciaPageModel() { Quantidade = 0 };
            else
                Ocorrencia = this.ReturnSessionValue<OcorrenciaPageModel>(SessionModel);
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var responseOcorrencia = IntegrationAPI.InvokeObject<ApplicationResponse<ContaPalavrasTextoResponse>, ContaPalavrasTextoRequest>(
              ConstOcorrencia.UrlOcorrenciaTermo,
              HttpMethod.Post,
              new ContaPalavrasTextoRequest() { Texto = Ocorrencia.Texto, Palavra = Ocorrencia.Palavra }
              );
            if (responseOcorrencia.Status == ApplicationResponseStatus.Success)
            {
                Ocorrencia.Quantidade = responseOcorrencia.Value.QuantidadeOcorrencias;
                this.SaveInSession<OcorrenciaPageModel>(Ocorrencia, SessionModel);
            }

            return RedirectToPage("/OcorrenciasTermo");
        }
    }
}