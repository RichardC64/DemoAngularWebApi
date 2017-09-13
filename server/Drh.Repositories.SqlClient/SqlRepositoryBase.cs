using System.Configuration;

namespace Drh.Repositories.SqlClient
{
    public abstract class SqlRepositoryBase : IRepositoryBase
    {
        protected SqlRepositoryBase() : this(ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString)
        { }
        protected SqlRepositoryBase(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; protected set; }
    }
}