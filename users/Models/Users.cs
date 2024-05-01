using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace users.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Roles { get; set; }
        public string ReportingManager { get; set; }
        public string Approver { get; set; }
        public string DepartmentName { get; set; }
        public bool IsVendor { get; set; }
        public string Phone { get; set; }

    }
}