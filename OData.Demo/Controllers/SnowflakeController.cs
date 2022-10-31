using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OData.Demo.Data;
using OData.Demo.Data.Entities;
using System.Collections.Generic;

namespace OData.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnowflakeController : ControllerBase
    {
        private readonly IGadgetsRepository _gadgetsRepository;
        public SnowflakeController(IGadgetsRepository gadgetsRepository)
        {
            _gadgetsRepository = gadgetsRepository;
            
        }
        [EnableQuery]
        [HttpGet("GetSnowflake")]
        public IActionResult Index()
        {
            //SnowflakeConnector.SnowflakeGetData();
            return Ok(SnowflakeConnector.SnowflakeGetData());
        }


        [EnableQuery]
        [HttpGet("GetDapperQuery")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Gadgets> gadgets = await _gadgetsRepository.GetSomeSimpleStuff();

            return Ok(gadgets);
        }
    }
}
