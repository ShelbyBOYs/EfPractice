using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Лабораторна 10 - Бібліотека (EF Core) ===\n");

        using var context = new LibraryDbContext();

        // Створюємо базу даних, якщо її немає
        context.Database.EnsureCreated();
        Console.WriteLine("База даних готова.\n");

        RunDemo(context);

        Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }

    static void RunDemo(LibraryDbContext context)
    {
        Console.WriteLine("=== Демонстрація роботи програми ===\n");

        AddSampleData(context);
        ShowAllReaders(context);
        ShowAllBooks(context);
        ShowBorrowsWithDetails(context);
        UpdateReaderName(context);

        Console.WriteLine("\nДемонстрація завершена.");
    }

    static void AddSampleData(LibraryDbContext context)
    {
        // Додаємо читачів
        var reader1 = new Reader { Name = "Максим Петренко" };
        var reader2 = new Reader { Name = "Олена Ковальчук" };
        context.Readers.Add(reader1);
        context.Readers.Add(reader2);
        context.SaveChanges();

        // Додаємо книги
        var book1 = new Book { Title = "Війна і мир", Author = "Лев Толстой" };
        var book2 = new Book { Title = "Гаррі Поттер і філософський камінь", Author = "Джоан Роулінг" };
        context.Books.Add(book1);
        context.Books.Add(book2);
        context.SaveChanges();

        // Додаємо видачі книг
        var borrow1 = new Borrow
        {
            ReaderId = reader1.Id,
            BookId = book1.Id,
            BorrowDate = DateTime.Now
        };

        var borrow2 = new Borrow
        {
            ReaderId = reader2.Id,
            BookId = book2.Id,
            BorrowDate = DateTime.Now.AddDays(-5)
        };

        context.Borrows.Add(borrow1);
        context.Borrows.Add(borrow2);
        context.SaveChanges();

        Console.WriteLine("Дані успішно додані!\n");
    }

    static void ShowAllReaders(LibraryDbContext context)
    {
        Console.WriteLine("--- Список читачів ---");
        var readers = context.Readers.ToList();
        foreach (var r in readers)
        {
            Console.WriteLine($"ID: {r.Id} | Ім'я: {r.Name}");
        }
        Console.WriteLine();
    }

    static void ShowAllBooks(LibraryDbContext context)
    {
        Console.WriteLine("--- Список книг ---");
        var books = context.Books.ToList();
        foreach (var b in books)
        {
            Console.WriteLine($"ID: {b.Id} | \"{b.Title}\" - {b.Author}");
        }
        Console.WriteLine();
    }

    static void ShowBorrowsWithDetails(LibraryDbContext context)
    {
        Console.WriteLine("--- Хто які книги взяв ---");
        var borrows = context.Borrows.Include(b => b.Reader).Include(b => b.Book).ToList();

                          
        foreach (var b in borrows)
        {
            Console.WriteLine($"{b.Reader?.Name} взяв книгу: \"{b.Book?.Title}\" ({b.BorrowDate.ToShortDateString()})");
        }
        Console.WriteLine();
    }

    static void UpdateReaderName(LibraryDbContext context)
    {
        var reader = context.Readers.FirstOrDefault();
        if (reader != null)
        {
            reader.Name = "Максим Петренко (оновлено)";
            context.SaveChanges();
            Console.WriteLine("Ім'я читача успішно оновлено!");
        }
    }
}

