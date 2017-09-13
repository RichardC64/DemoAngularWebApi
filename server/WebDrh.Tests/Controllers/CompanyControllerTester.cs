using System.Collections.Generic;
using System.Web.Http.Results;
using Drh.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDrh.Controllers;

namespace WebDrh.Tests.Controllers
{
    [TestClass]
    public class CompanyControllerTester
    {
        [TestMethod]
        public void ReturnOk()
        {
            var ctrl = new CompanyController();

            var result = ctrl.Get().GetAwaiter().GetResult() as OkNegotiatedContentResult<IEnumerable<Company>>;

            Assert.IsNotNull(result);
            //Assert.IsNotNull(result.Content);
        }
    }
}