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
    public class Student : Tests, IWriter
    {
        private int studentNum;
        private string firstName;
        private string lastName;
        private string ssn;
        private int classNum;
        private string classLetter;
        private string email;
        private string phoneNumber;
        

        public int StudentNum { get; set; }
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
        public int ClassNum { get; set; }
        public string ClassLetter { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void AddEmail(string email)
        {

            InsertEmail(email);
        }

        private void InsertEmail(string email)
        {
            this.studentNum = studentNum;
            var insertPersonQuery = "dbo.InsertStudentEmail @email, @studentNum";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { email = email, studentNum = studentNum });

            }
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            InsertPhone(phoneNumber);


        }

        private void InsertPhone(string phoneNumber)
        {
            this.studentNum = studentNum;
            var insertPersonQuery = "dbo.InsertStudentPhone @phoneNumber, @studentNum";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { phoneNumber = phoneNumber, studentNum = studentNum });

            }
        }


        public Student(int studentNum, string firstName, string lastName, string ssn, int classNum, string classLetter)
        {
            this.studentNum = studentNum;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ssn = ssn;
            this.classNum = classNum;
            this.classLetter = classLetter;

            try
            {
                InsertStudent();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine("Already Inserted");
            }

        }
        private void InsertStudent()
        {
            var insertPersonQuery = "dbo.InsertStudent @studentNum, @firstName, @lastName, @ssn, @classNum, @classLetter";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { studentNum = studentNum, firstName = firstName, lastName = lastName, ssn = ssn, classNum = classNum, classLetter = classLetter });

            }
        }

        public override void EnglishTest(int studentNum, int teacherId)
        {
            base.EnglishTest(studentNum, teacherId);
            InsertGrades(studentNum, teacherId);

            

        }

        private void InsertGrades(int studentNum, int teacherId)
        {
            var insertPersonQuery = "dbo.InsertStudentGrade @studentNum, @grade, @subjectName, @teacherId";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("StoreDB")))
            {
                connection.Execute(insertPersonQuery, new { studentNum = studentNum, grade = grade, subjectName = subjectName, teacherId = teacherId });

            }
        }

        public void Write()
        {
            Console.WriteLine("I love writing poems.");
        }
    }
}












