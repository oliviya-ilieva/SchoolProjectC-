using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SchoolProject
{
    internal class EnglishTeacher : Teacher
    {
        public string subject = "English";
        public EnglishTeacher(int teacherId, string firstName, string lastName, string ssn) : base(teacherId, firstName, lastName, ssn)
        {

        }

        public override void Introduction()
        {
            Console.WriteLine($"I am {FirstName} and I teach {subject}.");
        }
    }
}
