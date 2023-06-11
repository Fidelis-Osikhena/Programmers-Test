using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programmers_Test.Data;
using Programmers_Test.Models;
using System.Web.Mvc;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using JsonResult = Microsoft.AspNetCore.Mvc.JsonResult;
using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using ValidateAntiForgeryTokenAttribute = Microsoft.AspNetCore.Mvc.ValidateAntiForgeryTokenAttribute;

namespace Programmers_Test.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.EmployeeId = new SelectList(_context.Employees, "EmployeeId", "EmployeeName");
            return View(new TicketViewModel());
        }

        // ...

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                var ticket = new Ticket
                {
                    // Assign properties from your ViewModel to your Model
                    Project = ticketViewModel.Project,
                    DepartmentId = ticketViewModel.DepartmentId,
                    EmployeeId = ticketViewModel.EmployeeId,
                    Description = ticketViewModel.Description,
                    DateTimeSubmitted = DateTime.Now
                    
                };

                _context.Add(ticket);
                await _context.SaveChangesAsync();

                // After saving the ticket, redirect to the same page to refresh it.
                return RedirectToAction(nameof(Create));
            }

            // If ModelState is not valid, return the same view with the current model to show validation errors.
            return View(ticketViewModel);
        }



        public ActionResult GetEmployees(int departmentId)
        {
            if (departmentId > 0)
            {
                var employees = _context.Employees
                    .Where(e => e.DepartmentId == departmentId)
                    .Select(e => new { e.EmployeeId, e.EmployeeName });
                return Json(employees, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<IActionResult> Search(string searchString, string sortOrder)
        {
            ViewData["ProjectSort"] = sortOrder == "Project" ? "project_desc" : "Project";
            ViewData["DepartmentSort"] = sortOrder == "Department" ? "department_desc" : "Department";
            ViewData["DateSort"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["RequestorSort"] = sortOrder == "Requestor" ? "requestor_desc" : "Requestor";

            var tickets = from t in _context.Tickets
                          .Include(t => t.Department)  // Include the Department related to each Ticket
                          .Include(t => t.Employee)    // Include the Employee related to each Ticket
                          select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                tickets = tickets.Where(s => s.Project.Contains(searchString)
                                       || s.Department.DepartmentName.Contains(searchString)
                                       || s.Employee.EmployeeName.Contains(searchString)
                                       || s.Description.Contains(searchString)
                                       || s.DateTimeSubmitted.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Project":
                    tickets = tickets.OrderBy(t => t.Project);
                    break;
                case "project_desc":
                    tickets = tickets.OrderByDescending(t => t.Project);
                    break;
                case "Department":
                    tickets = tickets.OrderBy(t => t.Department.DepartmentName);
                    break;
                case "department_desc":
                    tickets = tickets.OrderByDescending(t => t.Department.DepartmentName);
                    break;
                case "Date":
                    tickets = tickets.OrderBy(t => t.DateTimeSubmitted);
                    break;
                case "date_desc":
                    tickets = tickets.OrderByDescending(t => t.DateTimeSubmitted);
                    break;
                case "Requestor":
                    tickets = tickets.OrderBy(t => t.Employee.EmployeeName);
                    break;
                case "requestor_desc":
                    tickets = tickets.OrderByDescending(t => t.Employee.EmployeeName);
                    break;
            }
            var viewModel = new TicketSearchViewModel
            {
                Tickets = await tickets.AsNoTracking().ToListAsync(),
                SearchString = searchString
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<JsonResult> ProjectTicketCounts()
        {
            var projectTicketCounts = await _context.Tickets
                .GroupBy(t => t.Project)
                .Select(g => new { Project = g.Key, Count = g.Count() })
                .ToListAsync();

            return Json(projectTicketCounts);
        }

        public ActionResult Chart()
        {
            return View();
        }








    }

}
