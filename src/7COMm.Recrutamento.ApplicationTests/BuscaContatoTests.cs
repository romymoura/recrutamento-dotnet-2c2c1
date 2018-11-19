//using _7COMm.Recrutamento.Application.ActionModel;
using _7COMm.Recrutamento.Application.Controllers;
using _7COMm.Recrutamento.CrossCuting.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace _7COMm.Recrutamento.ApplicationTests
{
    [TestClass]
    public class BuscaContatoTests
    {
        private RecrutamentoController RecrutamentoController { get; set; }

        public BuscaContatoTests()
        {
            //RecrutamentoController = new RecrutamentoController();
        }

        [TestMethod]
        public async Task BuscaContatoTest_1()
        {
            //Domain.Entities.Contato.ContatoService contatoFactory = new Domain.Contato.ContatoService();
            //BuscaContatoRequest request = new BuscaContatoRequest
            //{
            //    QuantidadeRegistro = 5,
            //    Busca = "vinicius",
            //    ListaContatos = new[] {
            //        (Domain.Contato.Contato)contatoFactory.Create("vinicius", "545646548"),
            //        (Domain.Contato.Contato)contatoFactory.Create("lucas", "45468846545"),
            //        (Domain.Contato.Contato)contatoFactory.Create("fedatto", "47864654"),
            //        (Domain.Contato.Contato)contatoFactory.Create("humberto", "884654545"),
            //        (Domain.Contato.Contato)contatoFactory.Create("jimmy", "213215844"),
            //        (Domain.Contato.Contato)contatoFactory.Create("christian", "218484545"),
            //        (Domain.Contato.Contato)contatoFactory.Create("mike", "879872512"),
            //        (Domain.Contato.Contato)contatoFactory.Create("akkio", "51518321"),
            //        (Domain.Contato.Contato)contatoFactory.Create("lex", "1351218484"),
            //        (Domain.Contato.Contato)contatoFactory.Create("eric", "5151183511")
            //    }
            //};
            //ApplicationResponse<BuscaContatoResponse> expected = new ApplicationResponse<BuscaContatoResponse>(new BuscaContatoResponse { ListaContatos = new[] { request.ListaContatos[0] } });
            //ApplicationResponse<BuscaContatoResponse> obtained = await RecrutamentoController.BuscaContato(request);

            //if (!(obtained.Status == ApplicationResponseStatus.Success))
            //{
            //    Assert.Fail("A resposta da controller não é um OkObjectResult.");
            //}
            //else
            //{
            //    CollectionAssert.AreEqual(expected.Value.ListaContatos, (obtained.Value).ListaContatos);
            //}
        }
    }
}
