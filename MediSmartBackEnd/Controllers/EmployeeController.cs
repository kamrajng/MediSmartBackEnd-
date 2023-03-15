using MediSmartBackEnd.Data;
using MediSmartBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using smartTestproj.Models;
using System.Numerics;
using System.Reflection;

namespace MediSmartBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller

    {
        private readonly EmployeeAPIDbContext dbContext;

        public EmployeeController(EmployeeAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async  Task<IActionResult> GetEmployees()
        {
            return Ok(await dbContext.Employees.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEmployeeRequest addEmployeeRequest)
        {
            
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                Email = addEmployeeRequest.Email,
                Phone = addEmployeeRequest.Phone,
                Gender = addEmployeeRequest.Gender,
                Status = addEmployeeRequest.Status,
                Age = addEmployeeRequest.Age.ToString(),
                Bio = addEmployeeRequest.Bio,
                Address = addEmployeeRequest.Address,
                Edu = addEmployeeRequest.Edu,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now
            };
            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            

            var employee = await dbContext.Employees.FindAsync(id);
                
                if (employee != null)
            {
                employee.FirstName = updateEmployeeRequest.FirstName;
                employee.LastName = updateEmployeeRequest.LastName;
                employee.Email = updateEmployeeRequest.Email;
                employee.Phone = updateEmployeeRequest.Phone;
                employee.Gender = updateEmployeeRequest.Gender;
                employee.Status = updateEmployeeRequest.Status;
                employee.Age = updateEmployeeRequest.Age.ToString();
                employee.Bio = updateEmployeeRequest.Bio;
                employee.Edu = updateEmployeeRequest.Edu;
                employee.Address = updateEmployeeRequest.Address;
                employee.LastModifiedDate= DateTime.Now;    

                await dbContext.SaveChangesAsync();

                return Ok(employee);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await dbContext.Employees.FindAsync(id);

            if (employee != null)
            {
                dbContext.Remove(employee);
                await dbContext.SaveChangesAsync();

                return Ok(employee);
            }

            return NotFound();
        }
            
}
    }
