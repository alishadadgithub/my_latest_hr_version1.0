using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HR.Models;

namespace HR.Models
{
    public class EmployeeIndexViewModel 
    {
        public int PkemployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeLastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeePhoneNumber { get; set; }
        
        public string EmployeeFinancialNumber { get; set; }
        public String EmployeeImageName { get; set; }
      
     

    }
}
