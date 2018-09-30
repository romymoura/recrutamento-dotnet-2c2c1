using _7COMm.Recrutamento.Application.ActionModel;
using _7COMm.Recrutamento.Application.Controllers;
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
			RecrutamentoController = new RecrutamentoController();
		}

		[TestMethod]
		public async Task PaginacaoListaTeste()
		{
			PaginaListaRequest request = new PaginaListaRequest { IndicePagina=1, TamanhoPagina = 3 , Lista = new[] { "A", "C", "B", "F", "E", "F", "HG" } };
			ActionResult<PaginaListaResponse> expected = new ActionResult<PaginaListaResponse>(new PaginaListaResponse { ListaPaginada = new[] { "F", "E", "F" } });
			ActionResult<PaginaListaResponse> obtained = await RecrutamentoController.PaginaLista(request);

            if (!(obtained.Result is OkObjectResult))
            {
                Assert.Fail("A resposta da controller não é um OkObjectResult.");
            }
            else
            {
                CollectionAssert.AreEqual(expected.Value.ListaPaginada, ((PaginaListaResponse)((OkObjectResult)obtained.Result).Value).ListaPaginada);
            }
		}
	}
}
