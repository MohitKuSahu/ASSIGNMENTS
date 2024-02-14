using System;
using System.Linq;
using System.Collections.Generic;


public class Class1
{
    
    public static void Linq()
        
    {
        // Student collection
        IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
                new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
                new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
            };

        // LINQ Query Syntax to find out teenager students
        var teenAgerStudent = from s in studentList   // query syntax
                              where s.Age > 12 && s.Age < 20
                              select s;

        var teenAgerStudents = studentList.Where(s => s.Age > 12 && s.Age < 20)  //method syntax
                                  .ToList<Student>();

        Console.WriteLine("Teen age Students:");

        foreach (Student std in teenAgerStudent)
        {
            Console.WriteLine(std.StudentName);
        }
    }
}

public class Student
{

    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; } 

}
