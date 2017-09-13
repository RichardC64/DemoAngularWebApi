using System;
using System.Linq;
using System.Threading.Tasks;
using Drh.Dtos;
using Drh.Repositories;
using Drh.Repositories.SqlClient;
using Drh.Services.EntitiesExtensions;

namespace Drh.Services
{
    public class PersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ICompanyRepository _companyRepository;

        #region ctors
        public PersonService() : this(new SqlPersonRepository(), new SqlCompanyRepository())
        { }
        public PersonService(IPersonRepository personRepository, ICompanyRepository companyRepository)
        {
            _personRepository = personRepository;
            _companyRepository = companyRepository;
        } 
        #endregion

        //public async Task<CompanyPersonsDto> LoadByCompanyAsync(int idCompany,int pageIndex, int pageSize)
        //{
        //    if (pageIndex < 0) throw new ArgumentException("pageIndex must be > 0", nameof(pageIndex));
        //    if (pageSize <= 0) throw new ArgumentException("pageIndex must be >= 0", nameof(pageSize));

        //    var company = await _companyRepository.LoadByIdAsync(idCompany);
        //    // si la compagnie n'existe pas, on retourne null
        //    if (company == null) return null;

        //    // récupération des persons de la company
        //    var persons = (await _personRepository.LoadByCompanyAsync(idCompany, pageIndex, pageSize))
        //        .Select(person => person.ToPersonDto());
        //    // calcul du nombre de persons dans la company
        //    var personsCount = await _personRepository.CountByCompanyAsync(idCompany);

        //    return new CompanyPersonsDto(idCompany,company.Name,persons,personsCount);
        //}

        public async Task<CompanyPersonsDto> LoadByCompanyAsync(int idCompany, int pageIndex, int pageSize)
        {
            if (idCompany <= 0) throw new ArgumentException("idCompany must be > 0", nameof(idCompany));
            if (pageIndex < 0) throw new ArgumentException("pageIndex must be > 0", nameof(pageIndex));
            if (pageSize <= 0) throw new ArgumentException("pageIndex must be >= 0", nameof(pageSize));

            var company = await _companyRepository.LoadByIdAsync(idCompany);
            // si la compagnie n'existe pas, on retourne null
            if (company == null) return null;

            // récupération des persons de la company et du nombre total de persons
            var persons = await _personRepository.LoadByCompanyAndCountAsync(idCompany, pageIndex, pageSize);

            return new CompanyPersonsDto(idCompany, company.Name, persons.Items.Select(p=>p.ToPersonDto()), persons.TotalCount);
        }

    }
}
