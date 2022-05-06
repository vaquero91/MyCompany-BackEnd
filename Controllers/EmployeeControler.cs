using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyCompany_BackEnd.Context;
using MyCompany_BackEnd.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyCompany_BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControler : Controller
    {
        private readonly DataContext _context;

        public EmployeeControler(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            var query = _context.AllEmployees.Include(r => r.department).Where(r => r.Active == true);

            return Ok(query);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetID(int id)
        {
            var query = _context.AllEmployees.FindAsync(id);

            return Ok(query);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee employee)
        {
            //TODO: crear objecto employee y agregar fields faltantes
            Employee employee1 = new Employee() {Active = true, FirstName = employee.FirstName,};
            employee.Active = true;

            _context.AllEmployees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = employee.PK_Employee }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> DeactivateEmployee(int id)
        {
            var employee = await _context.AllEmployees.FindAsync(id);
            if (employee == null)
            {
                return NoContent();
            
            }
            employee.Active = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // TODO: update call 
    }
}
