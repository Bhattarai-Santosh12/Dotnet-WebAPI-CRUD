using ASP_DotNet_WebAPI.Data;
using ASP_DotNet_WebAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly ApplicationDbContext dbcontext;

    public EmployeeController(ApplicationDbContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    [HttpGet]
    public IActionResult GetAllEmployee()
    {
        var allEmployees = dbcontext.Employees.ToList();
        return Ok(allEmployees);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetEmployeeById(Guid id)
    {
        var employee = dbcontext.Employees.Find(id);

        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
    {
        var employeeEntity = new Employee()
        {
            Name = addEmployeeDto.Name,
            Email = addEmployeeDto.Email,
            PhoneNumber = addEmployeeDto.PhoneNumber,
            Salary = addEmployeeDto.Salary,
        };

        dbcontext.Employees.Add(employeeEntity);
        dbcontext.SaveChanges();
        return Ok(employeeEntity);
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
    {
        var employee = dbcontext.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }

        // Update the employee's properties with the new values from updateEmployeeDto
        employee.Name = updateEmployeeDto.Name;
        employee.Email = updateEmployeeDto.Email;
        employee.PhoneNumber = updateEmployeeDto.PhoneNumber;
        employee.Salary = updateEmployeeDto.Salary;

        dbcontext.SaveChanges();
        return Ok(employee);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult DeleteEmployee(Guid id)
    {
        var employee = dbcontext.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        dbcontext.Employees.Remove(employee);
        dbcontext.SaveChanges();
        return Ok(employee);
    }
}
