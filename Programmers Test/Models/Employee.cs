namespace Programmers_Test.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; } // Foreign key

        // Navigation properties
        public Department Department { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
