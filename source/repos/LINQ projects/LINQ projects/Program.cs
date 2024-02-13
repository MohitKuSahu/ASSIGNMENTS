using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IList<Players> PlayerList = new List<Players>()
            {
                new Players(){ ID=101,Name="SALAH",matches=2 },
                new Players(){ ID=102,Name="NUNEZ",matches=1 },
                new Players(){ ID=101,Name="GAKPO",matches=3 },
                new Players(){ ID=101,Name="JOTA" ,matches=7}

            };


            // 0.     from s in studentList               QueryStyle language
            //        where s.Age > 12 && s.Age < 20
            //       select s.StudentName;

             var selected = PlayerList.Where(s => s.Name.Contains("O") && s.matches>3);

             var selected1 = PlayerList.Where(s => s.matches >=3 ).Where(s => s.matches < 20);

              //3.  from s in studentList
             //     orderby s.StudentName, s.Age
            //      select new { s.StudentName, s.Age }; Taking multiple values to dispLAY



            //foreach (var player in selected)
            //{
            //    Console.WriteLine(player.Name);
            //}
        }
    }
    public class Players
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int matches {  get; set; }
        
     
    }
       
}
