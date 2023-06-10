namespace Programmers_Test.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        // Navigation properties
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
