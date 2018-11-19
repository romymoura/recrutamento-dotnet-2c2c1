//using _7COMm.Recrutamento.Application.ActionModel;
using _7COMm.Recrutamento.Application.Controllers;
using _7COMm.Recrutamento.CrossCuting.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace _7COMm.Recrutamento.ApplicationTests
{
    [TestClass]
    public class PaginaListaTests
    {
		private RecrutamentoController RecrutamentoController { get; set; }

		public PaginaListaTests()
		{
			//RecrutamentoController = new RecrutamentoController();
		}

		[TestMethod]
		public async Task PaginacaoListaTeste()
		{
			//PaginaListaRequest request = new PaginaListaRequest { IndicePagina=1, TamanhoPagina = 3 , Lista = new[] { "A", "C", "B", "F", "E", "F", "HG" } };
   //         ApplicationResponse<PaginaListaResponse> expected = new ApplicationResponse<PaginaListaResponse>(new PaginaListaResponse { ListaPaginada = new[] { "F", "E", "F" } });
   //         ApplicationResponse<PaginaListaResponse> obtained = await RecrutamentoController.PaginaLista(request);

   //         if (!(obtained.Status == ApplicationResponseStatus.Success))
   //         {
   //             Assert.Fail("A resposta da controller não é um OkObjectResult.");
   //         }
   //         else
   //         {
   //             CollectionAssert.AreEqual(expected.Value.ListaPaginada, (obtained.Value).ListaPaginada);
   //         }
		}
	}
}
