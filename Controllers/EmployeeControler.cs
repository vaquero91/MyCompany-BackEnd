using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyCompany_BackEnd.Context;
using MyCompany_BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using MyCompany_BackEnd.DTO;
using MyCompany_BackEnd.NewFolder;

namespace MyCompany_BackEnd.Controllers
{
    // TODO: ADD documentacion
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControler : Controller
    {
        private readonly DataContext _context;

        public EmployeeControler(DataContext context)
        {
            _context = context;
        }

        #region Get Calls
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
        #endregion

        #region POST calls
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(EmployeeDTO employee)
        {
            //TODO: crear objecto employee y agregar fields faltantes
            Employee employee1 = new Employee() {Active = true,
                FirstName = employee.FirstName,
                LastName = employee.LastName, 
                FK_Department = employee.FK_Department};
            //employee.Active = true;

            _context.AllEmployees.Add(employee1);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetID), new { id = employee1.PK_Employee }, employee);
        }
        #endregion

        #region PUT calls
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
 

        [HttpPut] //    TODO modificar para recivir employeeDTO
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDTO employee)
        {
            //var employeeDB = await _context.AllEmployees.FindAsync(employee.PK_Employee);
            var employeeDB = await _context.AllEmployees.FindAsync(employee.PK_Employee);
            if(employeeDB == null)
            {
                return BadRequest();
            }

            employeeDB.FirstName = employee.FirstName;
            employeeDB.LastName = employee.LastName;
            employeeDB.FK_Department = employee.FK_Department;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        #endregion
    }
}
