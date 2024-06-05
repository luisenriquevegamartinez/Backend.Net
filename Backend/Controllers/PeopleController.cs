using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController([FromKeyedServices("peopleService")]IPeopleService peopleService) { 
            _peopleService = peopleService;
        }

        [HttpGet("all")]
        public List<People> Get() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> Get(int id) { 
            var people = Repository.People.FirstOrDefault(p => p.Id == id);

            if (people == null)
            {
                return NotFound();
            } else
            {
                return Ok(people);
            }
        }

        [HttpGet("search/{search}")]
        public List<People> Get(string search) => 
            Repository.People.Where( p => p.Name.ToLower().Contains(search.ToLower())).ToList();

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (_peopleService.IsInvalid(people))
            {
                return BadRequest();
            }
            Repository.People.Add(people);
            return NoContent();
        }
    }

    public class Repository
    {
        public static List<People> People = new List<People>()
        {
            new People{ Id = 1, Name = "Luis", Brithday = new DateTime(1991, 06, 28)},
            new People{ Id = 2, Name = "Luisa", Brithday = new DateTime(1994, 03, 27)},
            new People{ Id = 3, Name = "Emanuel", Brithday = new DateTime(2018, 09, 21)},
            new People{ Id = 4, Name = "Joel", Brithday = new DateTime(2021, 04, 17)},
        };
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Brithday { get; set; }
    }
}
