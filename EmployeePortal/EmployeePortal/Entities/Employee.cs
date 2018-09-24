using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeePortal.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public int GenderID { get; set; }
        public string GenderDesc { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public int DocumentID { get; set; }
        public string DocumentDesc { get; set; }
        public bool SSC { get; set; }
        public bool Inter { get; set; }
        public bool Degree { get; set; }
        public string Education { get; set; }
    }
}