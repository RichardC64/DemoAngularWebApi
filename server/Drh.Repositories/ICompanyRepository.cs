using System.Collections.Generic;
using System.Threading.Tasks;
using Drh.Entities;

namespace Drh.Repositories
{
    public interface ICompanyRepository : IRepositoryBase
    {
        Task<IEnumerable<Company>> LoadAllAsync();
        Task<Company> LoadByIdAsync(int idCompany);
    }
}