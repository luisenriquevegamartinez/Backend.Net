using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(
            Numbers numbers, 
            [FromHeader] string Host,
            [FromHeader(Name = "Content-Length")] string ContentLength)
        {
            Console.WriteLine($"Host: {Host}");
            Console.WriteLine($"Content-Length: {ContentLength}");
            return numbers.A - numbers.B;
        }

        [HttpPut]
        public decimal Update(decimal a, decimal b)
        {
            return a - b;
        }

        [HttpDelete]
        public decimal Remove(decimal a, decimal b)
        {
            return a - b;
        }
    }
    public class Numbers
    {
        public decimal A { get; set; }
        public decimal B { get; set; }
    }

}
