using _7COMm.Recrutamento.CrossCuting.Enuns;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace _7COMm.Recrutamento.Business.Services.Integration.Bases
{
    public abstract class BasesAPI : BaseIDispose
    {
        public HttpClient _client = null;
        public IConfiguration Configuration { get; }
        public static string UrlApi;
        public BasesAPI(IConfiguration configuration)
        {
            Configuration = configuration;
            UrlApi = Configuration.GetSection("AppConfiguration")["apiUrl"];
        }
        public BasesAPI()
        {
        }

        #region Destructor
        ~BasesAPI()
        {
            this.Dispose();
        }
        #endregion
    }
}
