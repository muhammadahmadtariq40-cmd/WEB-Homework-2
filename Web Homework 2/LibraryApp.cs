using System;
using System.Collections.Generic;
using LibraryData;

namespace LibraryApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepo = new BookRepository();
            MemberRepository memberRepo = new MemberRepository();
            BackupHelper backupHelper = new BackupHelper();

            while (true)
            {
                Console.WriteLine("\nMenu ");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Add Member");
                Console.WriteLine("4. View All Members");
                Console.WriteLine("5. Issue Book to Member");
                Console.WriteLine("6. Return Book ");
                Console.WriteLine("7. Export Books to JSON");
                Console.WriteLine("8. Import Books from JSON");
                Console.WriteLine("9. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Book b = new Book();
                    Console.Write("Enter Book ID: ");
                    b.BookId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Title: ");
                    b.Title = Console.ReadLine();
                    Console.Write("Enter Author: ");
                    b.Author = Console.ReadLine();
                    Console.Write("Enter Stock: ");
                    b.Stock = int.Parse(Console.ReadLine());

                    bookRepo.AddBook(b);
                }
                else if (choice == "2")
                {
                    List<Book> books = bookRepo.ShowBooks();
                    foreach (var b in books)
                    {
                        Console.WriteLine("ID: " + b.BookId + " | Title: " + b.Title + " | Author: " + b.Author + " | Stock: " + b.Stock);
                    }
                }
                else if (choice == "3")
                {
                    Member m = new Member();
                    Console.Write("Enter Member ID: ");
                    m.MemberId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    m.Name = Console.ReadLine();

                    memberRepo.AddMember(m);
                }
                else if (choice == "4")
                {
                    List<Member> members = memberRepo.ShowMembers();
                    foreach (var m in members)
                    {
                        Console.WriteLine("ID: " + m.MemberId + " | Name: " + m.Name);
                    }
                }
                else if (choice == "5")
                {
                    Console.Write("Enter Book ID: ");
                    int bid = int.Parse(Console.ReadLine());
                    Console.Write("Enter Member ID: ");
                    int mid = int.Parse(Console.ReadLine());

                    bool success = bookRepo.IssueBook(bid, mid);
                    if (success)
                    {
                        Console.WriteLine("Book Issued Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Issue Failed!");
                    }
                }
                else if (choice == "6")
                {
                    Console.Write("Enter Issue ID: ");
                    int iid = int.Parse(Console.ReadLine());

                    bool success = bookRepo.ReturnBook(iid);
                    if (success)
                    {
                        Console.WriteLine("Book Returned Successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Return Failed!");
                    }
                }
                else if (choice == "7")
                {
                    Console.Write("Enter file path: ");
                    string path = Console.ReadLine();
                    List<Book> books = bookRepo.ShowBooks();
                    backupHelper.SaveToJson(books, path);
                    Console.WriteLine("Exported to JSON!");
                }
                else if (choice == "8")
                {
                    Console.Write("Enter file path: ");
                    string path = Console.ReadLine();
                    List<Book> books = backupHelper.ReadFromJson(path);
                    foreach (var b in books)
                    {
                        Console.WriteLine("Title: " + b.Title + " | Stock: " + b.Stock);
                    }
                }
                else if (choice == "9")
                {
                    break;
                }
            }
        }
    }
}