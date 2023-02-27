using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        readonly IRepository store;
        public PersonController(IRepository store)
        {
            this.store = store;
        }
        [HttpGet]
        public IActionResult GetAllPers()
        {
            var res = store.GetAllPersons();
            return Ok(res);
        }
    }
}
