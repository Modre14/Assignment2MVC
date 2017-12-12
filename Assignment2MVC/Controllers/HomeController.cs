using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2MVC;
using ClassLibrary;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment2MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult SubmitForm()
        {
            var model = new SubmissionForm();
          
          
            return View(model);
        }

        public IActionResult ShowSubmissions()
        {
            var model = new SubmissionFormFileConnection();
            
            return View(model);
        }

        public IActionResult ShowSerialNumber()
        {

            var model = new SerialNumber();

            return View(model);
        }

     
    }
}
