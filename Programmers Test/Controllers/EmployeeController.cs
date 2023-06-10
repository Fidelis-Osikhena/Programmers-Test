using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmers_Test.Data;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Employee/GetByDepartment/
    [HttpGet("GetByDepartment/{departmentId}")]
    public async Task<IActionResult> GetByDepartment(int departmentId)
    {
        var employees = await _context.Employees
            .Where(e => e.DepartmentId == departmentId)
            .Select(e => new { id = e.EmployeeId, name = e.EmployeeName })
            .ToListAsync();

        return Ok(employees);
    }
}
