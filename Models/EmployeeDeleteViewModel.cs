﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class EmployeeDeleteViewModel
    {

        public int PkemployeeId { get; set; }
        public string EmployeeFirstName { get; set; }

        public string EmployeeLastName { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public string EmployeeFinancialNumber { get; set; }
    }
}
