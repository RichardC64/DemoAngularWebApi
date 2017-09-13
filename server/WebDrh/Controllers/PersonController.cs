using System.Threading.Tasks;
using System.Web.Http;
using Drh.Services;

namespace WebDrh.Controllers
{
    public class PersonController : ApiController
    {
        private readonly PersonService _personService = new PersonService();

        public async Task<IHttpActionResult> Get(int id, int pageIndex, int pageSize)
        {
            return Ok(await _personService.LoadByCompanyAsync(id, pageIndex, pageSize));
        }
    }
}