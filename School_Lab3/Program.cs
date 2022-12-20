using School_Lab3.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace School_Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            m.start();


        }

        //Sql Kolla alla personal

        //Select concat(Fname,' ', Lname) As Name, WorkTitle, Lesson From Employee
        //Join Title on TitleId = FK_TitleId
        //join SubjectSchool on SubjectSchoolId = FK_SchoolSubjectId
        //Where WorkTitle = 'Teacher'       -- Principal, Nurse, Janitor, Additional_Staff

        //Sql Kolla alla Betyg för den senaste månaden

        //Select concat(Student.Fname,' ', Student.LName) As Student, DateOfGrade, GivenGrade, Lesson, concat (Employee.FName, ' ', Employee.LName) As Teacher From Grade
        //Join Student on StudentId = FK_StudentId
        //join Employee on EmployeeId = FK_EmployeeId
        //join SubjectSchool on SubjectSchoolId = FK_SchoolSubjectId
        //Where DateOfGrade Between '2022-12-01' and '2022-12-31'

        //Sql Kollar på alla snittbetyg

        //Select Lesson, max(GivenGrade)' Högsta', min(GivenGrade)'Minsta', Avg(GivenGrade)'Snitt Betyg' From Grade
        //Join SubjectSchool on SubjectSchoolId = FK_EmployeeId
        //Group By Lesson

        //Sql Lägga till student

        //insert into Student(FK_ClassId, FName, LName, DateOfBirth, PhoneNr, Sex)
        //Values(5,'Cher','Meatloaf','2004-01-07',0702569958,'A');
    }
}






