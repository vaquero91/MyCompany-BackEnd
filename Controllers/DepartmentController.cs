using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyCompany_BackEnd.Context;
using MyCompany_BackEnd.Models;

namespace MyCompany_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;
        public DepartmentController(DataContext dataContext) 
        {
            _context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> Get()
        {
            var dep =  _context.Departments.Where(x => x.Active == true);
            return Ok(dep);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetID(int id)
        {
            var dep = _context.Departments.FindAsync(id);
            return Ok(dep);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeactivateDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NoContent();

            }
            department.Active = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Department>> Post(string departmentName)
        {
            Department department = new Department() { DepartmentName = departmentName, Active = true };
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = department.PK_Department }, department); //TODO crear metodo de GET por ID repetir en Employee
        }
    }
}
