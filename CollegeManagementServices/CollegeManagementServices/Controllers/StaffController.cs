using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagementServices.Controllers
{
    public class StaffController : Controller
    {
        [Authorize(Roles="Staff")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
