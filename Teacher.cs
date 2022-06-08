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
    public abstract class Teacher
    {
        private int teacherId;
        private string firstName;
        private string lastName;
        private string ssn;




        public int TeachderId { get; set; }
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

        public string SSN { get; set; }

        public Teacher(int teacherId, string firstName, string lastName, string ssn)
        {
            this.teacherId = teacherId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ssn = ssn;

            InsertTeacher();


        }
        private void InsertTeacher()
        {
            try
            {
                var insertPersonQuery = "dbo.InsertTeacher @teacherId, @firstName, @lastName, @ssn";
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDb")))
                {
                    connection.Execute(insertPersonQuery, new
                    {
                        teacherId = teacherId,
                        firstName = firstName,
                        lastName = lastName,
                        ssn = ssn
                    });

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Already Inserted");
            }



        }

        public void AddEmail(string email)
        {
            InsertEmail(email);

        }
        private void InsertEmail(string email)
        {
            this.teacherId = teacherId;
            var insertPersonQuery = "dbo.InsertTeacherEmail @email, @teacherId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { email = email, teacherId = teacherId });

            }
        }
        public void AddPhoneNumber(string phoneNumber)
        {
            InsertPhone(phoneNumber);


        }

        private void InsertPhone(string phoneNumber)
        {
            this.teacherId = teacherId;
            var insertPersonQuery = "dbo.InsertTeacherPhone @phoneNumber, @teacherId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { phoneNumber = phoneNumber, teacherId = teacherId });

            }
        }
        public void AddSubject()
        {
            InsertSubject();


        }
        private void InsertSubject()
        {
            Console.WriteLine("Please add valid subject.");
            string subject = Console.ReadLine();
            Console.WriteLine("Please add your valid Id");
            string id = Console.ReadLine();
            var insertPersonQuery = "dbo.InsertTeacherSubject @subject, @id";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { subject = subject, id = id });

            }
        }



        public void AddClass()
        {
            InsertClassTeacher();

        }

        public void AddClassLetter()
        {
            InsertClassLetter();
        }

        private void InsertClassTeacher()
        {
            Console.WriteLine("Please add valid Id.");
            string teacherId = Console.ReadLine();
            Console.WriteLine("Please add your valid class Num. 1 - 12");
            string classNum = Console.ReadLine();
            var insertPersonQuery = "dbo.InsertTeacherClass @teacherId, @classNum";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { teacherId = teacherId, classNum = classNum });

            }
        }
        private void InsertClassLetter()
        {
            Console.WriteLine("Please add valid Id.");
            int teacherId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please add valid class letter. A - G");
            string classLetter = Console.ReadLine();
            var insertPersonQuery = "dbo.InsertTeacherClassLetter @teacherId, @classLetter";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { teacherId = teacherId, classLetter = classLetter });

            }
        }
        public abstract void Introduction();

        public void AbsencesStudents()
        {
            AddAbsences();
        }

        private void AddAbsences()
        {
            Console.WriteLine("Please add valid Student Number.");
            int studentNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Please add valid Subject Name.");
            string subjectName = Console.ReadLine();
            Console.WriteLine("Please add valid Teacher Id.");
            int teacherId = int.Parse(Console.ReadLine());
            var insertPersonQuery = "dbo.InsertStudentAbsences @studentNum, @subjectName, @teacherId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { studentNum = studentNum, subjectName = subjectName, teacherId = teacherId });
            }
        }

    }
}



