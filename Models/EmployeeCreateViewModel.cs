using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Models
{
    public class EmployeeCreateViewModel
    {
        public int PkemployeeId { get; set; }
        [Required(ErrorMessage ="الرجاء إدخال الإسم")]
        public string EmployeeFirstName { get; set; }


        [Required(ErrorMessage = "الرجاء إدخال إسم الأب")]
        public string EmployeeMiddleName { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال العائلة")]
        public string EmployeeLastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EmployeeDateOfBirth { get; set; }


        public string EmployeePhoneNumber { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال الرقم المالي")]
        public string EmployeeFinancialNumber { get; set; }
        [Required(ErrorMessage = "الرجاء إدخال الرقم الآلي")]
        public int? EmployeeAutomatedNumber { get; set; }
        public string EmployeeImageUrl { get; set; }
        [Required(ErrorMessage = "الرجاء إدخال الرقم الضريبي")]
        public int? EmployeeTaxNumber { get; set; }



       
       public IEnumerable<SelectListItem> AcademicQualificationList { get; set; }
        [Display(Name = "المستوى  العلمي")]
        public int? FkacademicQualificationId { get; set; }

        
        public IEnumerable<SelectListItem> MaritalStatusList { get; set; }
        [Display(Name = " الوضع العائلي")]
        public int? FkmaritalStatusId { get; set; }


        [NotMapped]
        public IFormFile EmployeeImageURL { get; set; }




       
    } 
}
