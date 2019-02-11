using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ravi.learn.api.security.Models;

namespace ravi.learn.api.security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonsController : ControllerBase
    {
        private static List<Person> Persons = new List<Person>
        {
            new Person { Id = 1, FirstName = "John", LastName = "Smith", Address = new Address { Id = 1, Address1 = "123 Main Street", City = "Aldie", State = "VA", Zipcode = "20105" } },
            new Person { Id = 2, FirstName = "Jane", LastName = "Doe", Address = new Address { Id = 2, Address1 = "234 South Street", City = "Fairfax", State = "VA", Zipcode = "20111" } }

        }; 
        
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(Persons);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var person = Persons.Find(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}