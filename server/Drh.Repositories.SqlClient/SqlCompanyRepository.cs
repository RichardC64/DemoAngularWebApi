using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Drh.Entities;

namespace Drh.Repositories.SqlClient
{
    public class SqlCompanyRepository : SqlRepositoryBase, ICompanyRepository
    {
        #region ctors
        public SqlCompanyRepository() { }

        public SqlCompanyRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        private readonly string _sqlLoadAll = @"
            SELECT id, name
            FROM Companies
            ORDER BY name;";

        private readonly string _sqlLoadById = @"
            SELECT id, name
            FROM Companies
            WHERE id = @idCompany;";

        public async Task<IEnumerable<Company>> LoadAllAsync()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Company>(_sqlLoadAll);
            }
        }

        public async Task<Company> LoadByIdAsync(int idCompany)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<Company>(_sqlLoadById, new {idCompany});
            }
        }
    }
}