using _7COMm.Recrutamento.Application.ActionModel;
using _7COMm.Recrutamento.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace _7COMm.Recrutamento.ApplicationTests
{
	[TestClass]
	public class OrdenaListaTests
	{
		private RecrutamentoController RecrutamentoController { get; set; }

		public OrdenaListaTests()
		{
			RecrutamentoController = new RecrutamentoController();
		}

		[TestMethod]
		public async Task OrdenacaoListaTest_1()
		{
			OrdenaListaRequest request = new OrdenaListaRequest { Lista = new[] { "A", "C", "B" } };
			ActionResult<OrdenaListaResponse> expected = new ActionResult<OrdenaListaResponse>(new OrdenaListaResponse { ListaOrdenada = new[] { "A", "B", "C" } });
			ActionResult<OrdenaListaResponse> obtained = await RecrutamentoController.OrdenaLista(request);

            if (!(obtained.Result is OkObjectResult))
            {
                Assert.Fail("A resposta da controller não é um OkObjectResult.");
            }
            else
            {
                CollectionAssert.AreEqual(expected.Value.ListaOrdenada, ((OrdenaListaResponse)((OkObjectResult)obtained.Result).Value).ListaOrdenada);
            }
		}
	}
}
