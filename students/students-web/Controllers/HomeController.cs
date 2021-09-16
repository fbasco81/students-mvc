using students_web.Models;
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
        List<Student> students = new List<Student>();
        //List<Student> students = new List<Student>();

        public ActionResult Students()
        {
            /*var students = new List<Student>();
            var cnstr = ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT StudentId, FirstName, LastName FROM Student ORDER BY LastName, FirstName";

                var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    students.Add(new Student()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        Name = reader.GetString(reader.GetOrdinal("Firstname")),
                        Surname = reader.GetString(reader.GetOrdinal("Firstname")),
                    });

                }
            }*/



            return View();
        }

        public ActionResult StaticListStudents()
        {


            var student1 = new Student() { Id = 1, Name = "Gambas", Surname = "Edward" };
            students.Add(student1);
            var student2 = new Student() { Id = 2, Name = "Velina", Surname = "Angela" };
            students.Add(student2);
            var student3 = new Student() { Id = 3, Name = "Canta", Surname = "Tu" };
            students.Add(student3);
            var student4 = new Student() { Id = 4, Name = "Ancora", Surname = "Tu" };
            students.Add(student4);
            

            return View(students);

        }

        public ActionResult StudentDetails(string surname)
        {
            Student student = students.FirstOrDefault(s => s.Surname == surname);


            if (student == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(student);

            }


        }

    }

    
}