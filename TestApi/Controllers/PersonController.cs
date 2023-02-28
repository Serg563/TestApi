using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
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
        [ProducesResponseType((200), Type = typeof(IEnumerable<Person>))]
        public IActionResult GetAllPers()
        {
            var res = store.GetAllPersons();
            return Ok(res);
        }
        [HttpPost]
        [ProducesResponseType((201), Type = typeof(Person))]
        [ProducesResponseType((400), Type = typeof(string))]
        public IActionResult AddPerson([FromBody]Person person)
        {
            if(person.Id < 1) { return BadRequest("wrond id"); }
            store.Add(person); return Created("",person);
        }
        [HttpGet]
        [Route("id")]
        [ProducesResponseType((200))]
        [ProducesResponseType((404))]
        public IActionResult GetPersonById(int id)
        {
            var res = store.GetById(id);
            if (res == null) { return NotFound(); }
            return Ok(res);
        }

        [HttpDelete]
        [Route("id")]
        [ProducesResponseType((204))]
        [ProducesResponseType((404))]
        public IActionResult DeletePerson(int id)
        {
            try { store.Delete(id); }
            catch { return NotFound(); }
            return NoContent();
        }
        
    }
}
