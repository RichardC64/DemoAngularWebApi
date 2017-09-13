﻿using System.Collections.Generic;
using System.Web.Http.Results;
using Drh.Dtos;
using Drh.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebDrh.Controllers;

namespace WebDrh.Tests.Controllers
{
    [TestClass]
    public class PersonControllerTester
    {
        [TestMethod]
        public void ReturnOk()
        {
            var ctrl = new PersonController();

            var result = ctrl.Get(1, 0, 10).GetAwaiter().GetResult() as OkNegotiatedContentResult<IEnumerable<PersonDto>>;

            Assert.IsNotNull(result);
            //Assert.IsNotNull(result.Content);
        }
    }
}
