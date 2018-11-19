//using _7COMm.Recrutamento.Application.ActionModel;
using _7COMm.Recrutamento.Application.Controllers;
using _7COMm.Recrutamento.CrossCuting.DTO;
using _7COMm.Recrutamento.CrossCuting.Response;
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
            //RecrutamentoController = new RecrutamentoController();
        }

        [TestMethod]
        public async Task TemVencedorTest_1()
        {
            TemVencedorRequest request = new TemVencedorRequest();
            //request.Jogo = new[]  {
            //    new[] { "x", "o", "x" },
            //    new[] { "o", "o", "o" },
            //    new[] { "x", " ", "x" }
            //};

            ApplicationResponse<TemVencedorResponse> expected = new ApplicationResponse<TemVencedorResponse>(new TemVencedorResponse { TemVencedor = true });
            ApplicationResponse<TemVencedorResponse> obtained = await RecrutamentoController.TemVencedor(request);

            if (!(obtained.Status == ApplicationResponseStatus.Success))
            {
                Assert.Fail("A resposta da controller não é um OkObjectResult.");
            }
            else
            {
                Assert.AreEqual(expected.Value.TemVencedor, (obtained.Value).TemVencedor);
            }
        }
    }
}
