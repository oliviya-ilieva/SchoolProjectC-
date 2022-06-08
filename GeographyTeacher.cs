using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject
{
    internal class GeographyTeacher : Teacher
    {
        private string subject = "Geography";
        public GeographyTeacher(int teacherId, string firstName, string lastName, string ssn) : base(teacherId, firstName, lastName, ssn)
        {
        }
        public override void Introduction()
        {
            Console.WriteLine($"My name is {FirstName} and I teach {subject}.");
        }

    }
}
