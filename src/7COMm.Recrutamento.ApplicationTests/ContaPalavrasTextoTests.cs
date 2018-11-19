//using _7COMm.Recrutamento.Application.ActionModel;
using _7COMm.Recrutamento.Application.Controllers;
using _7COMm.Recrutamento.CrossCuting.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace _7COMm.Recrutamento.ApplicationTests
{
	[TestClass]
	public class ContaPalavrasTextoTests
	{
		//private RecrutamentoController RecrutamentoController { get; set; }

        public ContaPalavrasTextoTests()
		{
			//RecrutamentoController = new RecrutamentoController();
		}

		[TestMethod]
		public async Task ContaPalavrasTextoTest_1()
		{
            //ContaPalavrasTextoRequest request = new ContaPalavrasTextoRequest { Texto = "Todo teste da aplicacao é feito pela aplicacao de testes, podendo ser aplicado na aplicacao (Dilmês)", Palavra = "aplicacao" };
            //ApplicationResponse<ContaPalavrasTextoResponse> expected = new ApplicationResponse<ContaPalavrasTextoResponse>(new ContaPalavrasTextoResponse { QuantidadeOcorrencias = 3 });
            //ApplicationResponse<ContaPalavrasTextoResponse> obtained = await RecrutamentoController.ContaPalavrasTexto(request);

            //if (!(obtained.Status == ApplicationResponseStatus.Success))
            //{
            //    Assert.Fail("A resposta da controller não é um OkObjectResult.");
            //}
            //else
            //{
            //    Assert.AreEqual(expected.Value.QuantidadeOcorrencias, (obtained.Value).QuantidadeOcorrencias);
            //}
        }
	}
}
