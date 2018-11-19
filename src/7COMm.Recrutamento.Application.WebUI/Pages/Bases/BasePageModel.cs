using _7COMm.Recrutamento.Business.Services.Integration;
using _7COMm.Recrutamento.CrossCuting.Helpers.States;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;


namespace _7COMm.Recrutamento.Application.WebUI.Pages.Bases
{
    public abstract class BasePageModel : PageModel
    {
        #region Props
        public Api IntegrationAPI { get; set; }
        public readonly IConfiguration _configuration;
        public readonly RequestHandler _requestHandler;
        #endregion

        public BasePageModel(IConfiguration configuration, RequestHandler requestHandler)
        {
            _configuration = configuration;
            _requestHandler = requestHandler;

            if (IntegrationAPI == null)
                IntegrationAPI = new Api(_configuration);
        }

        /// <summary>
        /// Save data by name in Session
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="name"></param>
        protected void SaveInSession<T>(T value, string name)
        {
            _requestHandler.Set<T>(name, value);
        }
        /// <summary>
        /// Return data from Session by name
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        protected T ReturnSessionValue<T>(string name)
        {
            return _requestHandler.Get<T>(name);
        }
    }
}
