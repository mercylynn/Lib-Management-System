public class Loan
{
    public Book Book { get; }

    public Member Member { get; }

    public DateTime BorrowDate { get; }

    public DateTime DueDate { get; }

    public DateTime? ReturnDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

    public bool IsReturned => ReturnDate.HasValue;

    public Loan(Book book, Member member, int borrowingDays)
    {
        if (borrowingDays <= 0)
            throw new ArgumentException("Borrowing days must be positive.");

        Book = book;
        Member = member;

        BorrowDate = DateTime.Today;
        DueDate = BorrowDate.AddDays(borrowingDays);
    }

    public void MarkAsReturned()
    {
        if (IsReturned)
            throw new InvalidOperationException("Book has already been returned.");

        ReturnDate = DateTime.Today;
    }

    public bool IsOverdue()
    {
        return !IsReturned && DateTime.Today > DueDate;
    }
}