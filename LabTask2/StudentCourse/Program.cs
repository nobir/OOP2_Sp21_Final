using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Student
             */

            var s0 = new Student("Nobir 0", "s000", 3.0F);
            var s1 = new Student("Nobir 1", "s111", 3.11F);
            var s2 = new Student("Nobir 1", "s222", 3.22F);
            var s3 = new Student("Nobir 1", "s333", 3.33F);
            var s4 = new Student("Nobir 1", "s444", 3.44F);
            var s5 = new Student("Nobir 1", "s555", 3.55F);
            var s6 = new Student("Nobir 1", "s666", 3.66F);
            var s7 = new Student("Nobir 1", "s777", 3.77F);
            var s8 = new Student("Nobir 1", "s888", 3.88F);
            var s9 = new Student("Nobir 1", "s999", 3.99F);


            /*
             * Course
             */

            var c0 = new Course("c000", "OOP 1");
            var c1 = new Course("c111", "OOP 2");
            var c2 = new Course("c111", "Algorithm");


            /*
             * Operations
             */

            c0.AddStudent(s1, s3, s5, s7, s9);
            
            c0.PrintStudent();

            c0.RemoveStudent(s5);

            Console.WriteLine("\n=========  After Remove Student  ======\n");

            s5.PrintCourse();
            c0.PrintStudent();

            Console.WriteLine("\n=======================================\n");

            s2.AddCourse(c0, c1, c2);
            s2.PrintCourse();

            s2.RemoveCourse(c1);
            Console.WriteLine("\n=========  After Remove Course  ======\n");
            s2.PrintCourse();
            c1.PrintStudent();
        }
    }
}
