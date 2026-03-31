using System;
using System.Linq;
using System.Net.Http.Headers;

namespace EfPractice
{
    class Program
    {
        static void Main()
        {   // додавання
            using (var db = new AppDbContext())
            {
              

                var student = new Student
                { Name = "Ivan",
                  Status = "New"
                };
                db.Students.Add(student);
                Console.WriteLine($"State  before Save: {db.Entry(student).State}");
                db.SaveChanges();
                Console.WriteLine($"State  after Save: {db.Entry(student).State}");
            }
            // читання
            using (var db = new AppDbContext())
            {
                var student = db.Students.FirstOrDefault();
                Console.WriteLine("All students:");
                foreach (var i in db.Students.ToList())
                {
                    Console.WriteLine($"Id: {i.Id}, Name: {i.Name}, Status: {i.Status}");
                }
            }
            // оновлення
            using (var db = new AppDbContext())
            {
              Student student = db.Students.FirstOrDefault();
                if (student != null)
                {
                   student.Status = "Updated";
                   Console.WriteLine($"Update state before Save: {db.Entry(student).State}");
                   db.SaveChanges();
                }
            }
            // видалення
            using (var db = new AppDbContext())
            {
              
              Student student = db.Students.FirstOrDefault();

              if (student != null)
               {
                   db.Students.Remove(student);
                   Console.WriteLine($"Delete state before Save: {db.Entry(student).State}");
                   db.SaveChanges();
                   Console.WriteLine($"Delete state after Save: {db.Entry(student).State}");
               }
            }
            
        }
    }
}
