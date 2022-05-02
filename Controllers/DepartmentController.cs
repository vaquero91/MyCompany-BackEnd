using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany_BackEnd.Models;

namespace MyCompany_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<Department>> Get()
        {
            var dep = new Department { Active= false, DepartmentName = "Dev", PK_Department = 1};
            return Ok(dep);
        }
    }
}
