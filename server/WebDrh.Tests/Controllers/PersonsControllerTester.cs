using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDrh.Controllers;
using WebDrh.Models;

namespace WebDrh.Tests.Controllers
{
    [TestClass]
    public class PersonsControllerTester
    {
        [TestMethod]
        public void ReturnOk()
        {
            var ctrl = new PersonsController();

            var result = ctrl.Get().GetAwaiter().GetResult()as OkNegotiatedContentResult<PersonModel[]>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
        }
    }
}
