using System.Collections.Generic;
using ITI_MVC_Asssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Asssignment.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: DepartmentController
        public ActionResult GetAll()
        {
            return View();
        }

    }
}
