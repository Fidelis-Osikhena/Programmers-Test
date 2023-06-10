using System.ComponentModel.DataAnnotations.Schema;

namespace Programmers_Test.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public string Project { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public string Description { get; set; }

        public DateTime DateTimeSubmitted { get; set; }

    }
}
