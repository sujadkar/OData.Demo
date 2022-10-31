using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OData.Demo.Data;
using OData.Demo.Models;

namespace OData.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GadgetsController : ControllerBase
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public GadgetsController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [EnableQuery]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(_myWorldDbContext.Gadgets.AsQueryable());
        }

        [HttpGet("person")]
        [EnableQuery]
        public IActionResult GetPerson()
        {
            var person = new Person
            {
                Name = "Naveen",
                Id = 1,
                BankAccounts = new List<BankAccount>
                {
                    new BankAccount
                    {
                        AccountId = 1111,
                        BankName = "Bank 1"
                    },
                    new BankAccount
                    {
                        AccountId = 2222,
                        BankName = "Bank 2"
                    }
                }
            };
            var result = new List<Person>();
            result.Add(person);
            return Ok(result);
        }
    }
}
