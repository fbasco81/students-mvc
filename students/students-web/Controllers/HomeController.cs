using students_web.Models;
using students_web.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace students_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Students()
        {
            var studentService = new StudentService();
            var students = studentService.GetStudents();
            return View(students);
        }
 
    }
}