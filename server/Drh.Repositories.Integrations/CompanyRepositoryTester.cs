using System;
using System.Linq;
using Drh.Repositories.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drh.Repositories.Integrations
{
    [TestClass]
    public class CompanyRepositoryTester
    {
        private ICompanyRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new SqlCompanyRepository();
        }

        [TestMethod]
        public void ConnectionStringSetted()
        {
            var connectionString = "toto";
            _repository = new SqlCompanyRepository(connectionString);

            Assert.AreEqual(connectionString, _repository.ConnectionString);
        }

        [TestMethod]
        public void ConnectionStringInitialized()
        {
            Assert.IsNotNull(_repository.ConnectionString);
        }

        [TestMethod]
        public void LoadAllOk()
        {
            var items = _repository.LoadAllAsync().GetAwaiter().GetResult();

            Assert.IsNotNull(items);
            Console.WriteLine($"{items.Count()} companies");

            foreach (var item in items)       {
                Console.WriteLine($"{item.Id} : {item.Name}");
            }
        }

        [TestMethod]
        public void LoadByIdOk()
        {
            var item = _repository.LoadByIdAsync(1).GetAwaiter().GetResult();

            Assert.IsNotNull(item);
                Console.WriteLine($"{item.Id} : {item.Name}");
        }
    }
}