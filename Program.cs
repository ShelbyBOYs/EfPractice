using System;
using System.Linq;
using System.Net.Http.Headers;

namespace EfPractice
{
    class Program
    {
        static void Main()
        {
             using var db = new AppDbContext();

            db.Database.EnsureCreated();

            var student = new Student();
            student.Name = "Ivan";
            db.Students.Add(student);
            db.SaveChanges();

            Console.WriteLine("Students:");
            foreach (var i in db.Students.ToList())
            {
                Console.WriteLine($"{i.Name}:{i.Id}");
            }

            var first = db.Students.FirstOrDefault();
            if (first != null) {

                first.Name = "Petro";
                db.SaveChanges();
            
            }

            var dl = db.Students.FirstOrDefault();
            if (dl != null) { 
                db.Students.Remove(dl);
                db.SaveChanges();
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
