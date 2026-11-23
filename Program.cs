using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;

Library library = new Library();

bool running = true;

while (running)
{
    Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Register Student");
    Console.WriteLine("3. Register Staff");
    Console.WriteLine("4. View Books");
    Console.WriteLine("5. Borrow Book");
    Console.WriteLine("6. Return Book");
    Console.WriteLine("7. View Loans");
    Console.WriteLine("0. Exit");

    Console.Write("\nChoose an option: ");
    string? choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                Console.Write("Book ID: ");
                int bookId = int.Parse(Console.ReadLine()!);

                Console.Write("Title: ");
                string title = Console.ReadLine()!;

                Console.Write("Author: ");
                string author = Console.ReadLine()!;

                library.AddBook(new Book(bookId, title, author));

                Console.WriteLine("Book added successfully!");
                break;

            case "2":
                Console.Write("Member ID: ");
                int studentId = int.Parse(Console.ReadLine()!);

                Console.Write("Student name: ");
                string studentName = Console.ReadLine()!;

                library.RegisterMember(
                    new StudentMember(studentId, studentName));

                Console.WriteLine("Student registered!");
                break;

            case "3":
                Console.Write("Member ID: ");
                int staffId = int.Parse(Console.ReadLine()!);

                Console.Write("Staff name: ");
                string staffName = Console.ReadLine()!;

                library.RegisterMember(
                    new StaffMember(staffId, staffName));

                Console.WriteLine("Staff registered!");
                break;

            case "4":
                foreach (Book book in library.GetBooks())
                {
                    Console.WriteLine(
                        $"{book.Id} | {book.Title} | {book.Author} | " +
                        $"{(book.IsAvailable ? "Available" : "Borrowed")}");
                }
                break;

            case "5":
                Console.Write("Book ID: ");
                int borrowBookId = int.Parse(Console.ReadLine()!);

                Console.Write("Member ID: ");
                int borrowMemberId = int.Parse(Console.ReadLine()!);

                library.BorrowBook(borrowBookId, borrowMemberId);

                Console.WriteLine("Book borrowed successfully!");
                break;

            case "6":
                Console.Write("Book ID: ");
                int returnBookId = int.Parse(Console.ReadLine()!);

                Console.Write("Member ID: ");
                int returnMemberId = int.Parse(Console.ReadLine()!);

                library.ReturnBook(returnBookId, returnMemberId);

                Console.WriteLine("Book returned successfully!");
                break;

            case "7":
                foreach (Loan loan in library.GetLoans())
                {
                    Console.WriteLine(
                        $"{loan.Book.Title} | {loan.Member.Name} | " +
                        $"Due: {loan.DueDate:d} | " +
                        $"{(loan.IsReturned ? "Returned" :
                            loan.IsOverdue() ? "Overdue" : "Active")}");
                }
                break;

            case "0":
                running = false;
                Console.WriteLine("Goodbye!");
                break;

            default:
                Console.WriteLine("Invalid menu option.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}