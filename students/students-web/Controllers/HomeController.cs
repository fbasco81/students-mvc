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
        [HttpGet]
        public ActionResult Students()
        {
            var studentService = new StudentService();
            var students = studentService.GetStudents();
            return View(students);
        }

        [HttpGet]
        public ActionResult StudentDetail(int studentId)
        {
            var studentService = new StudentService();
            var student = studentService.GetStudent(studentId);
            return View(student);
        }

        [HttpGet]
        public ActionResult NewStudent()
        {
            var student = new Student() { Id = -1 };
            return View("StudentDetail", student);
        }

        [HttpPost]
        public ActionResult SaveStudent(Student student)
        {
            var studentService = new StudentService();
            var result = studentService.SaveStudent(student);

            return View("StudentSaveResult", result);
        }

        [HttpPost]
        public ActionResult DeleteStudent(int studentId)
        {
            var studentService = new StudentService();
            var result = studentService.DeleteStudent(studentId);

            return View("StudentDeleteResult", result);
        }
    }
}