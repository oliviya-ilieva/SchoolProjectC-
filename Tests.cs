using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace SchoolProject
{
    public class Tests
    {

        public int grade;
        public string subjectName;
        public int pointsQ1;
        public int pointsQ2;
        public int pointsQ3;
        public int pointsQ4;
        public int sumPoints;
        public string option;
        private string password = "test";

        public virtual void EnglishTest(int studentNum, int teacherId)
        {



            subjectName = "English";

            Console.WriteLine("This is your english test. To begin the test you have to put correct password");
            PasswordValidation();
       
            Console.WriteLine($"Hello. You have to have 90 points to pass the test.");
            Console.WriteLine("Q1:  My daughter said I should take my umbrella, and  [just as well],  [just as good], [just as lucky] too. While I was out it started pouring with rain.");
            option = Console.ReadLine().ToLower();
            if (option != "just as good")
            {
                Console.WriteLine($"Wrong answer. Zero points. ");
                pointsQ1 = 0;
            }
            else
            {
                pointsQ1 = 30;
            }

            Console.WriteLine("Q2: It's often said that there's a  [a thick line],  [a fine line], [a long line] between genius and madness.");
            option = Console.ReadLine().ToLower();
            if (option != "a fine line")
            {
                Console.WriteLine($"Wrong answer. Zero points.");
                pointsQ2 = 0;
            }
            else
            {
                pointsQ2 = 30;
            }

            Console.WriteLine("Q3: There's only one diving board, but if we  [take goes],  [take turns], [take tries] diving everyone will have plenty of dives.");
            option = Console.ReadLine().ToLower();
            if (option != "take turns")
            {
                Console.WriteLine($"Wrong answer. Zero points.");
                pointsQ3 = 0;
            }
            else
            {
                pointsQ3 = 30;
            }

            sumPoints = pointsQ1 + pointsQ2 + pointsQ3;
            if (sumPoints < 30)
            {
                Console.WriteLine($"You can't pass the test. You have less than 30 points.");
                grade = 2;
            }
            else if (sumPoints < 60)
            {
                grade = 4;
            }
            else
            {
                Console.WriteLine($"Success. You have {sumPoints}  points. ");
                grade = 6;
            }




        }

        
        
        
        public virtual void GeographyTest(int studentNum, int teacherId)
        {

            subjectName = "Geography";
            Console.WriteLine("This is your english test. To begin the test you have to put correct password");
            PasswordValidation();
            Console.WriteLine($"Hello. You have to have 90 points to pass the test. Every true questions gives you 30 points. Every wrong - 0.");
            Console.WriteLine("Q1: What is the name of the tallest mountain in the world? ");
            option = Console.ReadLine().ToLower();
            if (option != "mount everest")
            {
                Console.WriteLine($"Wrong answer. Zero points. ");
                pointsQ1 = 0;
            }
            else
            {
                pointsQ1 = 30;
            }

            Console.WriteLine("Which country has the largest population in the world?");
            option = Console.ReadLine().ToLower();
            if (option != "china")
            {
                Console.WriteLine($"Wrong answer. Zero points.");
                pointsQ2 = 0;
            }
            else
            {
                pointsQ2 = 30;
            }

            Console.WriteLine("What is the name of the longest river in Africa?");
            option = Console.ReadLine().ToLower();
            if (option != "the nile river")
            {
                Console.WriteLine($"Wrong answer. Zero points.");
                pointsQ3 = 0;
            }
            else
            {
                pointsQ3 = 30;
            }

            sumPoints = pointsQ1 + pointsQ2 + pointsQ3;
            if (sumPoints < 30)
            {
                Console.WriteLine($"You can't pass the test. You have less than 30 points.");
                grade = 2;
            }
            else if (sumPoints < 60)
            {
                grade = 4;
            }
            else
            {
                Console.WriteLine($"Success. You have {sumPoints}  points. ");
                grade = 6;
            }
        }

        private void PasswordValidation()
        {
            Console.Write("Password:");
            var pass = Console.ReadLine().ToLower();
            if (!pass.Equals(password))
            {
                throw new Exception("Incorrect password.");

            }
        }
            
        
    }
}

