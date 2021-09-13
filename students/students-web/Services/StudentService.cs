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
                        Surname = reader.GetString(reader.GetOrdinal("LastName")),
                    });

                }
            }
            
            return students;
        }

        public Student GetStudent(int studentId)
        {
            Student student = null;
            var cnstr = ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT StudentId, FirstName, LastName " +
                                        "FROM Student " +
                                        "WHERE StudentId=@StudentId";

                command.Parameters.AddWithValue("StudentId", studentId);

                var reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                if (reader.HasRows)
                {
                    reader.Read();
                    student = new Student()
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("StudentId")),
                        Name = reader.GetString(reader.GetOrdinal("Firstname")),
                        Surname = reader.GetString(reader.GetOrdinal("LastName")),
                    };
                }
            }

            return student;
        }

        public int SaveStudent(Student newStudent)
        {
            var student = GetStudent(newStudent.Id);
            if (student == null)
            {
                student = new Student() { Id = -1 };
            }
            else
            {
                student.Id = newStudent.Id;
            }
            
            student.Name = newStudent.Name;
            student.Surname = newStudent.Surname;

            int result;

            var cnstr = ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                var command = conn.CreateCommand();

                if (student.Id <= 0) // it's a new student
                {
                    command.CommandText = "INSERT INTO Student (FirstName, LastName) VALUES (@FirstName, @LastName) ";
                }
                else
                {
                    command.CommandText = "UPDATE Student SET FirstName=@FirstName, LastName=@LastName WHERE StudentId=@StudentId ";
                    command.Parameters.AddWithValue("StudentId", student.Id);
                }

                command.Parameters.AddWithValue("FirstName", student.Name);
                command.Parameters.AddWithValue("LastName", student.Surname);

                result = command.ExecuteNonQuery();
            }

            return result;
        }

        public int DeleteStudent(int studentId)
        {
            int result;

            var cnstr = ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString;
            using (var conn = new SqlConnection(cnstr))
            {
                conn.Open();
                var command = conn.CreateCommand();

                command.CommandText = "DELETE FROM Student WHERE StudentId=@StudentId ";
                command.Parameters.AddWithValue("StudentId", studentId);
                
                result = command.ExecuteNonQuery();
            }

            return result;
        }

    }
}