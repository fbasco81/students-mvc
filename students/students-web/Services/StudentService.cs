using students_web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace students_web.Services
{
    public class StudentService
    {
        public List<Student> GetStudents()
        {
            var students = new List<Student>();
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
            }
            
            return students;
        }
 
    }
}