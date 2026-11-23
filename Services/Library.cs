using LibraryManagementSystem.Models;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Services;

public class Library
{
    private readonly List<Book> books = new();
    private readonly List<Member> members = new();
    private readonly List<Loan> loans = new();

    public void AddBook(Book book)
    {
        if (books.Any(b => b.Id == book.Id))
            throw new InvalidOperationException("Book ID already exists.");

        books.Add(book);
    }

    public void RegisterMember(Member member)
    {
        if (members.Any(m => m.Id == member.Id))
            throw new InvalidOperationException("Member ID already exists.");

        members.Add(member);
    }

    public void BorrowBook(int bookId, int memberId)
    {
        Book? book = books.FirstOrDefault(b => b.Id == bookId);
        Member? member = members.FirstOrDefault(m => m.Id == memberId);

        if (book == null)
            throw new InvalidOperationException("Book not found.");

        if (member == null)
            throw new InvalidOperationException("Member not found.");

        if (!book.IsAvailable)
            throw new InvalidOperationException("Book is not available.");

        IBorrowingPolicy policy = (IBorrowingPolicy)member;

        int activeLoans = loans.Count(l =>
            l.Member.Id == memberId && !l.IsReturned);

        if (activeLoans >= policy.MaximumBooks)
            throw new InvalidOperationException("Borrowing limit reached.");

        book.Borrow();

        Loan loan = new Loan(book, member, policy.BorrowingDays);

        loans.Add(loan);
    }

    public void ReturnBook(int bookId, int memberId)
    {
        Loan? loan = loans.FirstOrDefault(l =>
            l.Book.Id == bookId &&
            l.Member.Id == memberId &&
            !l.IsReturned);

        if (loan == null)
            throw new InvalidOperationException("Active loan not found.");

        loan.MarkAsReturned();
        loan.Book.Return();
    }

    public IEnumerable<Book> GetBooks()
    {
        return books;
    }

    public IEnumerable<Member> GetMembers()
    {
        return members;
    }

    public IEnumerable<Loan> GetLoans()
    {
        return loans;
    }
}