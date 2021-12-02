using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementServices.Controllers
{
    public class StudentController : Controller
    {
        [Authorize(Roles="Student")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
