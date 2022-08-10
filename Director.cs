using System;
using System.Data;
using System.Text.RegularExpressions;

namespace SchoolProject
{
    public class Director
    {
        private const string Validation_Regex_Name_Pattern = "^[A-Z][a-zA-Z]*$";

        private int directorId;
        private string firstName;
        private string lastName;


        public Director(int directorId, string firstName, string lastName)
        {
            this.DirectorId = directorId;
            this.FirstName = firstName;
            this.LastName = lastName;
        }


        public int DirectorId { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (ValidateName(value))
                {
                    Console.WriteLine("Invalid Firstname!");
                    return;
                }
                this.firstName = value;
            }
        }

      

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (ValidateName(value))
                {
                    Console.WriteLine("Invalid Lastname!");
                    return;
                }
                this.lastName = value;
            }
        }

       

        public void RemoveTeacher(int teacherId)
        {
            RemoveTeacherPrivate(teacherId);
        }

        public void RemoveStudent(int studentNum)
        {

            RemoveStudentPrivate(studentNum);
        }

        public void AddWarningToTeacher()
        {
            InsertWarningToTeacher();
        }

        public void AddWarningToStudent()
        {

        }

        private static bool ValidateName(string value)
        {
            return !Regex.Match(value, Validation_Regex_Name_Pattern).Success;
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
                        DirectorId = DirectorId,
                        FirstName = FirstName,
                        LastName = LastName,

                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Already Inserted!");
            }
        }

        private void RemoveTeacherPrivate(int teacherId)
        {
            var insertPersonQuery = "dbo.RemoveTeacher @teacherId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new
                {
                    teacherId = teacherId
                });
            }
        }

        private void RemoveStudentPrivate(int studentNum)
        {
            var insertPersonQuery = "dbo.RemoveStudent @studentNum";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new
                {
                    studentNum = studentNum
                });
            }
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
                connection.Execute(insertPersonQuery,
                    new
                    {
                        warningText = warningText,
                        directorId = directorId,
                        teacherId = teacherId
                    });

            }
        }

        private void InsertWarningToStudent()
        {

        }


    }
}
