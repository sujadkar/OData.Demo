using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using OData.Demo.Data;

namespace OData.Demo.Controllers
{
    public class GadgetsOdataController : ControllerBase
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public GadgetsOdataController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_myWorldDbContext.Gadgets.AsQueryable());
        }
    }
}
