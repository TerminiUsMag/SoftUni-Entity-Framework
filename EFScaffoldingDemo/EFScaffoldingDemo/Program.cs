using EFScaffoldingDemo;
using Microsoft.EntityFrameworkCore;

using (SoftUniContext context = new SoftUniContext())
{
    var employees = await context.Employees.OrderByDescending(e => e.Salary).Where(e => e.DepartmentId == 7).ToListAsync();

    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Salary} -> {employee.Department?.Name}");
    }
}