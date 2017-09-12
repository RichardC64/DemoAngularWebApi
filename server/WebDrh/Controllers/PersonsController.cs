using System.Threading.Tasks;
using System.Web.Http;
using WebDrh.Models;

namespace WebDrh.Controllers
{
    public class PersonsController : ApiController
    {
        public Task<IHttpActionResult> Get()
        {
            return Task.FromResult<IHttpActionResult>(Ok(new[]
            {
                new PersonModel {FirstName = "Richard", LastName = "Clark", Id = 1},
                new PersonModel {FirstName = "Denis", LastName = "Voituron", Id = 2},
                new PersonModel {FirstName = "Christophe", LastName = "Peugnet", Id = 4}
            }));
        }
    }
}