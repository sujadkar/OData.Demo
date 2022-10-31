using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OData.Demo.Data;

namespace OData.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnowflakeController : ControllerBase
    {
        [EnableQuery]
        [HttpGet("GetSnowflake")]
        public IActionResult Index()
        {
            //SnowflakeConnector.SnowflakeGetData();
            return Ok(SnowflakeConnector.SnowflakeGetData());
        }
    }
}
