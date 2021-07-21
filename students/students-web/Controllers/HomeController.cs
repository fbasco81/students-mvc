using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace students_web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Students()
        {
            var students = new List<Student>();
            students.Add(new Student()
            {
                Id = 1,
                Name = "Francesco",
                Surname = "Basco"
            });

            students.Add(new Student()
            {
                Id = 2,
                Name = "Mario",
                Surname = "Rossi"
            });

            students.Add(new Student()
            {
                Id = 3,
                Name = "Enrico",
                Surname = "Verdi"
            });

            students.Add(new Student()
            {
                Id = 4,
                Name = "Gianni",
                Surname = "Blu"
            });
            return View(students);
        }

        
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}