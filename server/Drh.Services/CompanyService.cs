using System.Collections.Generic;
using System.Threading.Tasks;
using Drh.Entities;
using Drh.Repositories;
using Drh.Repositories.SqlClient;

namespace Drh.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        #region ctors
        public CompanyService() : this(new SqlCompanyRepository())
        {

        }
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        } 
        #endregion

        public Task<IEnumerable<Company>> LoadAllAsync()
        {
            return _companyRepository.LoadAllAsync();
        }
    }
}