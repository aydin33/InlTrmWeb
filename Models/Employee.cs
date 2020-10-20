using System;
using System.Collections.Generic;

namespace InlTrmWeb.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Costs = new HashSet<Costs>();
        }

        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int AuthLevel { get; set; }

        public virtual ICollection<Costs> Costs { get; set; }
    }
}
