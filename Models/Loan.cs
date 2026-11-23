public class Loan
{
    public Book Book { get; }

    public Member Member { get; }

    public DateTime BorrowDate { get; }

    public DateTime DueDate { get; }

    public DateTime? ReturnDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }

    public bool IsReturned => ReturnDate.HasValue;
}