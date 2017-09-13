using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Drh.Entities;
using Drh.Entities.Infra;

namespace Drh.Repositories.SqlClient
{
    public class SqlPersonRepository : SqlRepositoryBase, IPersonRepository
    {
        #region ctors
        public SqlPersonRepository()
        {}

        public SqlPersonRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        private readonly string _sqlLoadAll = @"
            SELECT id, firstname, lastname, idCompany
            FROM Persons
            WHERE idCompany = @idCompany
            ORDER BY lastname, firstname
            OFFSET @pageSize * @pageIndex ROWS 
            FETCH NEXT @pageSize ROWS ONLY;";

        private readonly string _sqlLoadCount = @"
            SELECT Count(*)
            FROM Persons
            WHERE IdCompany = @idCompany";

        private readonly string _sqlLoadAllAndCount = @"
            SELECT id, firstname, lastname, idCompany
            FROM Persons
            WHERE idCompany = @idCompany
            ORDER BY lastname, firstname
            OFFSET @pageSize * @pageIndex ROWS 
            FETCH NEXT @pageSize ROWS ONLY;

            SELECT Count(*)
            FROM Persons
            WHERE IdCompany = @idCompany";

        public async Task<IEnumerable<Person>> LoadByCompanyAsync(int idCompany, int pageIndex, int pageSize)
        {       
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Person>(_sqlLoadAll, new {idCompany, pageIndex, pageSize});
            }
        }

        public async Task<int> CountByCompanyAsync(int idCompany)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryFirstAsync<int>(_sqlLoadCount, new { idCompany });
            }
        }

        public async Task<PagedResult<Person>> LoadByCompanyAndCountAsync(int idCompany, int pageIndex, int pageSize)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var queryMulti =
                    connection.QueryMultipleAsync(_sqlLoadAllAndCount, new {idCompany, pageIndex, pageSize}))
                {
                    var persons = await queryMulti.Result.ReadAsync<Person>();
                    var count = (await queryMulti.Result.ReadAsync<int>()).Single();
                    return new PagedResult<Person>(persons, count);
                }
            }
        }
    }
}
