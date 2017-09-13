using System.Threading.Tasks;
using System.Web.Http;
using Drh.Services;

namespace WebDrh.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly CompanyService _companyService = new CompanyService();

        public async Task<IHttpActionResult> Get()
        {
            return Ok(await _companyService.LoadAllAsync());
        }
    }
}