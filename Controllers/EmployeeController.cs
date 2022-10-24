using HR.entity.Models;
using HR.Models;
using HR.services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HR.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IAcademicQualificationService _academicQualificationService;
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService,
            IAcademicQualificationService academicQualificationService,
            IMaritalStatusService maritalStatusService,
            IWebHostEnvironment hostingEnvironment)
        ///* public EmployeeController(IEmployeeService employeeService*/)
        {
            _employeeService = employeeService;
            _hostingEnvironment = hostingEnvironment;

            _academicQualificationService = academicQualificationService;
            _maritalStatusService = maritalStatusService;
            ;
        }
        public IActionResult Index()
        {

            try
            {
                var employees = _employeeService.GetAll().Select(e => new EmployeeIndexViewModel
                {
                    PkemployeeId = e.PkemployeeId,
                    EmployeeFirstName = e.EmployeeFirstName,
                    EmployeeMiddleName = e.EmployeeMiddleName,
                    EmployeeLastName = e.EmployeeLastName,

                    EmployeeFinancialNumber = e.EmployeeFinancialNumber,
                    EmployeePhoneNumber = e.EmployeePhoneNumber,

                    EmployeeDateOfBirth = (DateTime)e.EmployeeDateOfBirth,

                    EmployeeImageName = e.EmployeeImageUrl

                }).ToList();
                return View(employees);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
                throw;
            }







        }

        [HttpGet]
        public IActionResult Create()
        {
            var newemployee = new EmployeeCreateViewModel()
            {



                AcademicQualificationList = _academicQualificationService.GetAllAcademicQualification().Select(i => new SelectListItem
                {
                    Text = i.AcademicQualificationType,
                    Value = i.PkacademicQualificationId.ToString()
                }),

                MaritalStatusList = _maritalStatusService.GetAllMaritalStatus().Select(i => new SelectListItem
                {
                 Text =i.MaritalStatusType,
                 Value = i.PkmaritalStatusId.ToString()
                })

        
        };

        
    

            return View(newemployee);
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken] //prevents cross site forgery attacks

        public async  Task< IActionResult> Create(EmployeeCreateViewModel EmployeeModel)
        {

            if (ModelState.IsValid)
            {
                var newemployee = new Employee
                {
                    EmployeeFirstName = EmployeeModel.EmployeeFirstName,
                    EmployeeMiddleName = EmployeeModel.EmployeeMiddleName   ,
                    EmployeeLastName = EmployeeModel.EmployeeLastName,
                    EmployeeDateOfBirth =EmployeeModel.EmployeeDateOfBirth,
                    EmployeePhoneNumber = EmployeeModel.EmployeePhoneNumber,
                    EmployeeFinancialNumber = EmployeeModel.EmployeeFinancialNumber,
                    EmployeeAutomatedNumber = EmployeeModel.EmployeeAutomatedNumber,
                    EmployeeImageUrl = EmployeeModel.EmployeeImageUrl,
                    EmployeeTaxNumber = EmployeeModel.EmployeeTaxNumber,
                    FkacademicQualificationId = EmployeeModel.FkacademicQualificationId,
                    FkmaritalStatusId = EmployeeModel.FkmaritalStatusId
                };

                if (EmployeeModel.EmployeeImageURL != null && EmployeeModel.EmployeeImageURL.Length > 0)
                {
                 
                    string wwwRootPath = _hostingEnvironment.WebRootPath;
                   var fileName = Path.GetFileNameWithoutExtension(EmployeeModel.EmployeeImageURL.FileName);
                  var extension = Path.GetExtension(EmployeeModel.EmployeeImageURL.FileName);
                    newemployee.EmployeeImageUrl = fileName =fileName+ DateTime.UtcNow.ToString("yyyymmssfff") + extension;
                    var path = Path.Combine(wwwRootPath +"/images/employee/", fileName);
                    using (var filestream = new FileStream(path,FileMode.Create))
                    {
                        await EmployeeModel.EmployeeImageURL.CopyToAsync(filestream);
                    }
                    //await EmployeeModel.EmployeeImageURL.CopyToAsync(new FileStream(path, FileMode.Create));
                    //newemployee.EmployeeImageUrl = "/" + wwwRootPath + "/" + fileName;
                   
                }

                await   _employeeService.CreateAsync(newemployee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int EmployeeId)
        {
            var EditedEmployee = _employeeService.GetById(EmployeeId);
            if (EditedEmployee == null)
            {
                return NotFound();
            }
            var EmployeeModel = new EmployeeEditViewModel()
            {
                //PkemployeeId = EditedEmployee.PkemployeeId,
                EmployeeFirstName = EditedEmployee.EmployeeFirstName,
                EmployeeMiddleName = EditedEmployee.EmployeeMiddleName,
                EmployeeLastName = EditedEmployee.EmployeeLastName,
                EmployeeDateOfBirth = (DateTime)EditedEmployee.EmployeeDateOfBirth,
                EmployeePhoneNumber = EditedEmployee.EmployeePhoneNumber,
                EmployeeFinancialNumber = EditedEmployee.EmployeeFinancialNumber,
                EmployeeAutomatedNumber= EditedEmployee.EmployeeAutomatedNumber,
                EmployeeImageUrl = EditedEmployee.EmployeeImageUrl,
                EmployeeTaxNumber = EditedEmployee.EmployeeTaxNumber,
             
                //FkacademicQualificationId = EditedEmployee.FkacademicQualificationId,
                //FkmaritalStatusId = EditedEmployee.FkmaritalStatusId
            };

            return View(EmployeeModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async   Task< IActionResult> Edit(EmployeeEditViewModel EmployeeModel)
        {
            if (ModelState.IsValid)
            {
                var EditedEmployee = _employeeService.GetById(EmployeeModel.PkemployeeId);
                if (EditedEmployee == null)
                {
                    return NotFound();
                }

                EditedEmployee.EmployeeFirstName = EmployeeModel.EmployeeFirstName;
                EditedEmployee.EmployeeMiddleName = EmployeeModel.EmployeeMiddleName;
                EditedEmployee.EmployeeLastName = EmployeeModel.EmployeeLastName;
                EditedEmployee.EmployeeDateOfBirth = EmployeeModel.EmployeeDateOfBirth;
                EditedEmployee.EmployeePhoneNumber = EmployeeModel.EmployeePhoneNumber;
                EditedEmployee.EmployeeFinancialNumber = EmployeeModel.EmployeeFinancialNumber;
                EditedEmployee.EmployeeAutomatedNumber = EmployeeModel.EmployeeAutomatedNumber;
              

                EditedEmployee.EmployeeTaxNumber = EmployeeModel.EmployeeTaxNumber;
               
                //EditedEmployee.FkacademicQualificationId = EmployeeModel.FkacademicQualificationId;
                //EditedEmployee.FkmaritalStatusId = EmployeeModel.FkmaritalStatusId;

               
                if (EmployeeModel.EmployeeImageURL != null && EmployeeModel.EmployeeImageURL.Length > 0)
                {

                    string wwwRootPath = _hostingEnvironment.WebRootPath;
                    var fileName = Path.GetFileNameWithoutExtension(EmployeeModel.EmployeeImageURL.FileName);
                    var extension = Path.GetExtension(EmployeeModel.EmployeeImageURL.FileName);
                    EmployeeModel.EmployeeImageUrl = fileName = fileName + DateTime.UtcNow.ToString("yyyymmssfff") + extension;
                    var path = Path.Combine(wwwRootPath + "/images/employee/", fileName);
                    using (var filestream = new FileStream(path, FileMode.CreateNew))
                    {
                        await EmployeeModel.EmployeeImageURL.CopyToAsync(filestream);
                    }

                    EditedEmployee.EmployeeImageUrl = EmployeeModel.EmployeeImageUrl;
                }
                await _employeeService.UpdateAsync(EditedEmployee, EmployeeModel.PkemployeeId);
                return RedirectToAction(nameof(Index));

            }

            return View(EmployeeModel);
        }

        [HttpGet]
        public IActionResult Detail(int EmployeeId)
        {


            var employeeDetails = _employeeService.GetById(EmployeeId);

            if (employeeDetails == null)
            {
                return NotFound();
            }

            EmployeeDetailViewModel employeemodel = new EmployeeDetailViewModel() {

                PkemployeeId = employeeDetails.PkemployeeId,
                EmployeeFirstName= employeeDetails.EmployeeFirstName,
                EmployeeLastName = employeeDetails.EmployeeLastName,
                EmployeeDateOfBirth= (DateTime)employeeDetails.EmployeeDateOfBirth,
                EmployeeFinancialNumber= employeeDetails.EmployeeFinancialNumber,
                EmployeePhoneNumber=employeeDetails.EmployeePhoneNumber,
                EmployeeImageURL=employeeDetails.EmployeeImageUrl
                
            };
            return View(employeemodel);
        }


        [HttpGet]
        public IActionResult Delete(int EmployeeId)
        {
            var employeeToDelete = _employeeService.GetById(EmployeeId);
            if (employeeToDelete == null)
            {
                return NotFound();
            }

            var employeeModel = new EmployeeDeleteViewModel() {
                PkemployeeId = employeeToDelete.PkemployeeId,
                EmployeeFirstName= employeeToDelete.EmployeeFirstName,

            };


            return View(employeeModel);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async  Task< IActionResult> Delete(EmployeeDeleteViewModel EmployeeDeleteModel)
        //{
        //   await _employeeService.Delete(EmployeeDeleteModel.PkemployeeId);
        //    return RedirectToAction(nameof(Index));


        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRec(int EmployeeId)
        {
            //await _employeeService.Delete(employeeDelete.PkemployeeId);
            await _employeeService.Delete(EmployeeId);
            return RedirectToAction(nameof(Index));


        }

    }
}

        
