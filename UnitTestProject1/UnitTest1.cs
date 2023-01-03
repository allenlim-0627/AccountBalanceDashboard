using AccountBalance.Controllers;
using AccountBalance.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Mock<IAccountRepository> _repo = new Mock<IAccountRepository>();

        [TestMethod]
        public async Task TestMethod1()
        {
            var controller = new LoginController(_repo.Object);
            controller.Request = new HttpRequestMessage();
            //set the content somehow so that httpRequestMessage.Content.ReadAsStringAsync returns data 
            controller.Request.Content = new StringContent("", Encoding.UTF8, "application/json");
            controller.Configuration = new HttpConfiguration();
            var response = controller.Login("allen", "123");

            // Assert
            HttpResponseMessage product;
            //Console.WriteLine(response);
            var content = await response.Content.ReadAsStringAsync();
            //Assert.IsTrue(response.TryGetContentValue<HttpResponseMessage>(out product));
            Assert.IsNotNull(content);
            //Assert.AreEqual(response, HttpStatusCode.OK, "Admin,User");
            //Assert.AreEqual(content, "Admin,User");
        }
    }
}
