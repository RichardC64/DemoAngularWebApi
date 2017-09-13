using System.Collections.Generic;
using System.Threading.Tasks;
using Drh.Entities;
using Drh.Entities.Infra;

namespace Drh.Repositories
{
    public interface IPersonRepository : IRepositoryBase
    {
        Task<IEnumerable<Person>> LoadByCompanyAsync(int idCompany, int pageIndex, int pageSize);
        Task<int> CountByCompanyAsync(int idCompany);
        Task<PagedResult<Person>> LoadByCompanyAndCountAsync(int idCompany, int pageIndex, int pageSize);
    }
}