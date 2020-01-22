using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using employee.model;

namespace employee.Controllers
{
       public class EmployController : Controller
        {
            private readonly Interface empr;
            //dependancy injected object
            public EmployController(Interface empr1)
            {
                empr = empr1;
            }
        //Interface empr = new Employr();
        public ActionResult Search(int? id)
        {
            int ID = (int)((id == null) ? 1 : id);
            Employ emp1 = empr.GetEmploy(ID);
            ViewData["Employ"] = "emp1";
            return View(emp1);
        }
        //    if (emp1 != null)
        //    {
        //        return Content(emp1.Id + "\n" + emp1.Name + "\n" + emp1.Email + "\n" + emp1.dept);
        //    }
        //    return Content("emp does not exist");
        //}
        public IActionResult Index()
        {
            List<Employ> elist = empr.DisplayDetails();
            return View(elist);
        }
        public ViewResult AboutEmp()
        {
            Employ emp = empr.GetEmploy(2);
            //ViewBag.projectname = "employee";
            EmployProjectViewModel ep = new EmployProjectViewModel();
            ep.employ = emp;
            ep.projectname = "CBSE";
            return View(ep);
        }
        public IActionResult GetAllEmploy()
        {
            List<Employ> elist = empr.DisplayDetails().Where(e=>e.dept=="csf").ToList();
            return View("../Index.cshtml", elist);//absolute way of path 
        }
        }
}
   