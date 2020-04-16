using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTutorial1.Models;
using MyTutorial1.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyTutorial1.Controllers
{
    //[Route("[controller]")]
    [Authorize]
    //[AllowAnonymous]
    public class HomeController : Controller
    {
        private  IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(IEmployeeRepository employeeRepository,
                              IHostingEnvironment hostingEnvironment)
        {   
            _employeeRepository =  employeeRepository;  //new MockEmployeeRepository(); //employeeRepository;  interface holding implementation?
            this.hostingEnvironment = hostingEnvironment;
        }

        //[Route("")] usemvc
        //[Route("~/")]
        //[Route("[action]")]
        [AllowAnonymous]
        public ViewResult index()
        {
            // return _employeeRepository.GetEmployee(2).Name;
            var model= _employeeRepository.GetAllEmployee();
            return View(model);
        }

        // [Route("[action]/{id?}")]
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            //throw new Exception("Error in details view");

            //var x = _employeeRepository.GetAllEmployee();

            Employee employee = _employeeRepository.GetEmployee(id.Value);

            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound",id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,//_employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
            };
            //Employee model = _employeeRepository.GetEmployee(2);
            //default path is Views/Home
            // we use ../ to back one time from home to views
            //return View("test"); // we can also write the path with the extention if the file out of Views
            //return View("MyViews/test.cshtml"); //absolute path we can also use / or ~/
            //return View("../Test/Update"); //relevant path we don't use the extention
            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "Employee Details";
            //ViewBag.Employee = model;
            //ViewBag.PageTitle = "Employee Details";
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        //[Authorize]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)//we.use.[REQUIRED.ATTRIBUTE]
            {
                String uniqueFileName = ProcessUploadedFile(model);
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email=model.Email,
                    Department=model.Department,
                    PhotoPath= uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }

        [HttpGet]
        //[Authorize]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id=employee.Id,
                Name=employee.Name,
                Email=employee.Email,
                Department=employee.Department,
                ExistingPhotoPath=employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        //[Authorize]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)//we.use.[REQUIRED.ATTRIBUTE]
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;
                if(model.Photo != null)
                {
                    if (model.ExistingPhotoPath !=null)
                    {
                        String FilePath=Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(FilePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }
                _employeeRepository.Update(employee);
                return RedirectToAction("index");
                //if (model.Photo != null)//&& model.Photo.Count > 0
                //{
                //    //foreach(IFormFile photo in model.Photo)
                //    //{ repleace model.photo by photo  
                //    //the edit will be here and EmployeeCreateViewModel.cs viewModel jquery in Create.cshtml view
                //    String uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                //    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName; //Global unique identifier
                //    String FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                //    model.Photo.CopyTo(new FileStream(FilePath, FileMode.Create));
                //    //}
                //}
            }
            return View();
        }
        //this method created to handle processing for uploading file like photo
        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            String uniqueFileName = null;
            if (model.Photo != null)//&& model.Photo.Count > 0
            {
                //foreach(IFormFile photo in model.Photo)
                //{ repleace model.photo by photo  
                //the edit will be here and EmployeeCreateViewModel.cs viewModel jquery in Create.cshtml view
                String uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName; //Global unique identifier
                String FilePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
                
                //}
            }

            return uniqueFileName;
        }
    }
}
