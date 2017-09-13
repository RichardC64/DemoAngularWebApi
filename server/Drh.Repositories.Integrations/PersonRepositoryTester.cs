using System;
using System.Linq;
using Drh.Repositories.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Drh.Repositories.Integrations
{
    [TestClass]
    public class PersonRepositoryTester
    {
        private IPersonRepository _repository;

        [TestInitialize]
        public void Initialize()
        {
            _repository = new SqlPersonRepository();
        }

        [TestMethod]
        public void ConnectionStringSetted()
        {
            var connectionString = "toto";
            _repository = new SqlPersonRepository(connectionString);
            
            
            Assert.AreEqual(connectionString, _repository.ConnectionString);
        }

        [TestMethod]
        public void ConnectionStringInitialized()
        {
            Assert.IsNotNull(_repository.ConnectionString);
        }

        [TestMethod]
        public void LoadByCompanyAsyncOk()
        {
            var items = _repository.LoadByCompanyAsync(1, 0, 2).GetAwaiter().GetResult();

            Assert.IsNotNull(items);
            Assert.AreEqual(2, items.Count());
        }

        [TestMethod]
        public void LoadByCompanyAsyncNoDatasOk()
        {
            var items = _repository.LoadByCompanyAsync(1, 100000, 10).GetAwaiter().GetResult();

            Assert.IsNotNull(items);
            Assert.AreEqual(0, items.Count());
        }

        [TestMethod]
        public void CountByCompanyAsyncOk()
        {
            var count = _repository.CountByCompanyAsync(1).GetAwaiter().GetResult();

            Assert.IsNotNull(count);

            Console.WriteLine($"{count} persons");
           
        }
    }
}
