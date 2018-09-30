using _7COMm.Recrutamento.Application.ActionModel;
using _7COMm.Recrutamento.Application.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace _7COMm.Recrutamento.ApplicationTests
{
    [TestClass]
    public class TemVencedorTests
    {
        private RecrutamentoController RecrutamentoController { get; set; }

        public TemVencedorTests()
        {
            RecrutamentoController = new RecrutamentoController();
        }

        [TestMethod]
        public async Task TemVencedorTest_1()
        {
            TemVencedorRequest request = new TemVencedorRequest();
            request.Jogo = new[]  {
                new[] { "x", "o", "x" },
                new[] { "o", "o", "o" },
                new[] { "x", " ", "x" }
            };

            ActionResult<TemVencedorResponse> expected = new ActionResult<TemVencedorResponse>(new TemVencedorResponse { TemVencedor = true });
            ActionResult<TemVencedorResponse> obtained = await RecrutamentoController.TemVencedor(request);

            if (!(obtained.Result is OkObjectResult))
            {
                Assert.Fail("A resposta da controller não é um OkObjectResult.");
            }
            else
            {
                Assert.AreEqual(expected.Value.TemVencedor, ((TemVencedorResponse)((OkObjectResult)obtained.Result).Value).TemVencedor);
            }
        }
    }
}
