using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;

namespace SchoolProject
{
    public class Director
    {
        private int directorId;
        private string firstName;
        private string lastName;

        public int DirectorId { get; set; }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                if (!Regex.Match(firstName, "^[A-Z][a-zA-Z]*$").Success)
                    Console.WriteLine("Invalid Firstname.");
            }


        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                if (!Regex.Match(lastName, "^[A-Z][a-zA-Z]*$").Success)
                    Console.WriteLine("Invalid Lastname.");
            }
        }

        public Director(int directorId, string firstName, string lastName)
        {
            this.directorId = directorId;
            this.firstName = firstName;
            this.lastName = lastName;

           InsertDirector();
        }

        private void InsertDirector()
        {
            try
            {
                var insertPersonQuery = "dbo.InsertDirector @directorId, @firstName, @lastName";
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDb")))
                {
                    connection.Execute(insertPersonQuery, new
                    {
                        directorId = directorId,
                        firstName = firstName,
                        lastName = lastName,
                        
                    });

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Already Inserted");
            }
        }
            public void RemoveTeacher (int teacherId)
        {
            RemoveTeacherPrivate(teacherId);
        }

        public void RemoveStudent (int studentNum)
        {

            RemoveStudentPrivate(studentNum);            
        }

        private void RemoveTeacherPrivate(int teacherId)
        {
            var insertPersonQuery = "dbo.RemoveTeacher @teacherId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { teacherId = teacherId });

            }
        }


        private void RemoveStudentPrivate(int studentNum)
        {
            var insertPersonQuery = "dbo.RemoveStudent @studentNum";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { studentNum = studentNum });

            }

        }

        public void AddWarningToTeacher()
        {
            InsertWarningToTeacher();
        }

        public void AddWarningToStudent()
        {

        }

        private void InsertWarningToTeacher()
        {
            
            Console.Write("Insert your Valid Id: ");
            int directorId = int.Parse(Console.ReadLine());
            Console.Write("Insert Teacher Valid Id:");
            int teacherId = int.Parse(Console.ReadLine());
            Console.Write("Insert text warning:");
            string warningText = Console.ReadLine();
            var insertPersonQuery = "dbo.InsertTeacherWarning @warningText, @directorId, @teacherId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { warningText = warningText, directorId = directorId, teacherId = teacherId  });

            }
        }

        private void InsertWarningToStudent()
        {

        }




    }
}
