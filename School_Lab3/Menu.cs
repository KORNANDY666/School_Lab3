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
                Console.WriteLine("Välkommen till C# Skolan");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Gör nu ditt val");
                Console.WriteLine("");
                Console.WriteLine("1. Elever efter namnordning \n" +
                                  "2. Hämta Elev efter klass \n" +
                                  "3. Elev Info             \n" +
                                  "4. Aktuella ämnen        \n" +
                                  "5. Hur många Anställda per avdelning \n" +
                                  "6. Lägga till ny personal \n" +
                                  "7. Avsluta");
                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------");

                int input = checkNr();
                switch (input)

                {
                    case 1:
                        checkStudents(); //lab3
                        
                        break;
                    case 2:
                        class_student(); //lab3
                        break;
                    case 3:
                        StudentInfo();  //Uppgift 4
                        break;
                    case 4:
                        Subject();    // Uppgift 5
                        break;
                    case 5:
                        Total_Employee(); // Uppgift 3
                        break;
                    case 6:
                        AddEmployee(); // lab3
                        break;
                    case 7:
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
            int input = checkNr();


            if (input == 1)
            {
                Console.Clear();
                Console.WriteLine("Hur vill du ha din förnamns ordning.");
                Console.WriteLine("1. Stigande");
                Console.WriteLine("2. Fallande");
                int choice = checkNr();
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
                Console.Clear();
                Console.WriteLine("Hur vill du ha din efternamns ordning.");
                Console.WriteLine("1. Stigande");
                Console.WriteLine("2. Fallande");
                int choice = checkNr();
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



            Console.WriteLine("Vilken klass vill du kolla");
            int look = checkNr();
            using SchoolContext context = new SchoolContext();
            Console.WriteLine("--------------------------------------------");
            var myPerson = from Student in context.Students
                           where Student.FkClassId == look
                           orderby Student.Fname
                           select Student;

            foreach (var item in myPerson)
            {
                Console.WriteLine(item.FkClassId);
                Console.WriteLine(item.Fname);
                Console.WriteLine(item.Lname);
                Console.WriteLine(item.DateOfBirth);
                Console.WriteLine(item.PhoneNr);
                Console.WriteLine(item.Sex);

                Console.WriteLine(new string('-', (30)));


            }
        }

        public void StudentInfo()
        {
            Console.WriteLine("Student info ");
            using SchoolContext context = new SchoolContext();
            var myPerson = from Student in context.Students
                           orderby Student.Fname
                           select Student;
            Console.WriteLine("");
            Console.Clear();
            foreach (var item in myPerson)
            {
                Console.WriteLine(item.Fname);
                Console.WriteLine(item.Lname);
                Console.WriteLine(item.DateOfBirth);
                Console.WriteLine(item.PhoneNr);
                Console.WriteLine(item.Sex);

                Console.WriteLine(new string('-', (30)));


            }
        }

        public void Subject()
        {

            Console.WriteLine("Skolans aktuella ämnen");
            using SchoolContext context = new SchoolContext();
            var mySubject = from SubjectSchool in context.SubjectSchools
                           orderby SubjectSchool
                           select SubjectSchool;
            Console.Clear();
            Console.WriteLine("Skolan alla ämnen");
            Console.WriteLine("");

            foreach (var item in mySubject)
            {
                Console.WriteLine(item.Lesson);
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

        public void Total_Employee()
        {
            
            Console.WriteLine("Vilken avdelning vill du titta på? \n" +
                              "1. Lärare \n" +
                              "2. Tjänstemän \n" +
                              "3. Läkare \n" +
                              "4. Vaktmästare \n" +
                              "5. Övrig extra personal");
            int look = checkNr();
            using SchoolContext context = new SchoolContext();
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            var myPerson = from Employee in context.Employees
                           where Employee.FkTitleId == look
                           orderby Employee.EmployeeId
                           select Employee;

            foreach (var item in myPerson)
            {
                
                Console.WriteLine(item.Fname + " " + item.Lname);
                Console.WriteLine(item.HiredDate);
                

                Console.WriteLine(new string('-', (30)));


            }
            

        }



        public int checkNr()
        {
            int nr;
            while (!int.TryParse(Console.ReadLine(), out nr))
            {
                Console.WriteLine("inmatnings fel");
            }

            return nr;
        }
    }
}
