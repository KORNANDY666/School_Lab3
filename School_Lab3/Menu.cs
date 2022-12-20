using School_Lab3.Data;
using School_Lab3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;

namespace School_Lab3
{
    internal class Menu
    {

        public void start()
        {
            while (true)
            {


                Console.WriteLine("Gör nu ditt val");
                Console.WriteLine("1. Hämta alla elever \n" +
                                  "2. Hämta elever i en viss klass\n" +
                                  "3. Lägga till ny personal \n" +
                                  "4. Avsluta");

                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        checkStudents();
                        break;
                    case 2:
                        class_student();
                        break;
                    case 3:
                        AddEmployee();
                        break;
                        case 4:
                        System.Environment.Exit(0);
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("------------------------------------");
                Console.ReadKey();
                Console.Clear();
            }

        }


        public void checkStudents()
        {
            Console.WriteLine("I vilken list ordning vill du se dina elever? ");
            Console.WriteLine("1. Listordning efter förnamn");
            Console.WriteLine("2. Listordning efter efternamn");
            int input = int.Parse(Console.ReadLine());
           
            if (input == 1)
            {
                Console.WriteLine("Hur vill du ha din förnamns ordning.");
                Console.WriteLine("1. Stigande");
                Console.WriteLine("2. Fallande");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    using (var context = new SchoolContext())
                    {
                        var MyStudents = from a in context.Students orderby a.Fname select a;
                        Console.WriteLine("---------------------------------------------------");
                        foreach (var item in MyStudents)
                        {

                            Console.WriteLine(item.Fname + " " + item.Lname);
                        }
                    }

                }
                else if (choice == 2)
                {
                    using (var context = new SchoolContext())
                    {
                        var MyStudents = from a in context.Students.OrderByDescending(a => a.Fname) select a;
                        Console.WriteLine("---------------------------------------------------");
                        foreach (var item in MyStudents)
                        {

                            Console.WriteLine(item.Fname + " " + item.Lname);
                        }
                    }

                }

            }
            else if (input == 2)
            {
                Console.WriteLine("Hur vill du ha din efternamns ordning.");
                Console.WriteLine("1. Stigande");
                Console.WriteLine("2. Fallande");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    using (var context = new SchoolContext())
                    {
                        var MyStudents = from a in context.Students orderby a.Lname select a;
                        Console.WriteLine("---------------------------------------------------");
                        foreach (var item in MyStudents)
                        {

                            Console.WriteLine(item.Fname + " " + item.Lname);
                        }
                    }
                }
                else if (choice == 2)
                {
                    using (var context = new SchoolContext())
                    {
                        var MyStudents = from a in context.Students.OrderByDescending(a => a.Lname) select a;
                        Console.WriteLine("---------------------------------------------------");
                        foreach (var item in MyStudents)
                        {

                            Console.WriteLine(item.Fname + " " + item.Lname);
                        }
                    }

                }

            }

        }


        public void class_student()
        {
            


            Console.WriteLine("Skriv in en den klassen du vill titta på");
            int inputAge = Convert.ToInt32(Console.ReadLine()); 
            using SchoolContext context = new SchoolContext();
            Console.WriteLine("--------------------------------------------");
            var myPerson = from Student in context.Students
                           where Student.FkClassId == inputAge
                           orderby Student.Fname
                           select Student;
           
            foreach (var item in myPerson)
            {
                Console.WriteLine(item.Fname);
                Console.WriteLine(item.Lname);
                Console.WriteLine(item.DateOfBirth);
                Console.WriteLine(item.PhoneNr);
            
                Console.WriteLine(new string('-', (30)));


            }
        }

        public void AddEmployee()
        {

            using SchoolContext context = new SchoolContext();

            Employee a1 = new Employee();
            Console.Write("Förnamn : ");
            a1.Fname = Console.ReadLine();
            Console.Write("Efternamn : ");
            a1.Lname = Console.ReadLine();
            a1.DateOfBirth = DateTime.Now;
            a1.HiredDate = DateTime.Now;
            Console.Write("Telefon Nr : ");
            a1.PhoneNr = Console.ReadLine();
            Console.Write("Kön : ");
            a1.Sex = Console.ReadLine();
            Console.Write("Arbets titel : ");
            a1.FkTitleId = int.Parse(Console.ReadLine());
            Console.Write("Lektions Ämne : ");
            a1.FkSchoolSubjectId = int.Parse(Console.ReadLine());


            context.Employees.Add(a1);
            context.SaveChanges();
            Console.WriteLine("Databasen Uppdateras......");

        }

    }
}
