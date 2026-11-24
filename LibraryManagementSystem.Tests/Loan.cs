
using Xunit;

public class LoanTests
{
    [Fact]
    public void Constructor_ValidDetails_CreatesLoan()
    {
        // Arrange
        var book = new Book(1, "Clean Code", "Robert C. Martin");
        var member = new StudentMember(1, "Mary");

        // Act
        var loan = new Loan(book, member, 14);

        // Assert
        Assert.Equal(book, loan.Book);
        Assert.Equal(member, loan.Member);
        Assert.Equal(DateTime.Today, loan.BorrowDate);
        Assert.Null(loan.ReturnDate);
        Assert.False(loan.IsReturned);
    }

    [Fact]
    public void Constructor_ValidBorrowingDays_CalculatesDueDate()
    {
        // Arrange
        var book = new Book(1, "Clean Code", "Robert C. Martin");
        var member = new StudentMember(1, "Mary");

        // Act
        var loan = new Loan(book, member, 14);

        // Assert
        Assert.Equal(DateTime.Today.AddDays(14), loan.DueDate);
    }

    [Fact]
    public void Constructor_InvalidBorrowingDays_ThrowsArgumentException()
    {
        // Arrange
        var book = new Book(1, "Clean Code", "Robert C. Martin");
        var member = new StudentMember(1, "Mary");

        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Loan(book, member, 0));
    }

    [Fact]
    public void MarkAsReturned_SetsReturnDate()
    {
        // Arrange
        var book = new Book(1, "Clean Code", "Robert C. Martin");
        var member = new StudentMember(1, "Mary");
        var loan = new Loan(book, member, 14);

        // Act
        loan.MarkAsReturned();

        // Assert
        Assert.True(loan.IsReturned);
        Assert.NotNull(loan.ReturnDate);
        Assert.Equal(DateTime.Today, loan.ReturnDate);
    }

    [Fact]
    public void MarkAsReturned_AlreadyReturnedLoan_ThrowsInvalidOperationException()
    {
        // Arrange
        var book = new Book(1, "Clean Code", "Robert C. Martin");
        var member = new StudentMember(1, "Mary");
        var loan = new Loan(book, member, 14);

        loan.MarkAsReturned();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            loan.MarkAsReturned());
    }

    [Fact]
    public void IsOverdue_NotReturnedLoan_ReturnsFalseBeforeDueDate()
    {
        // Arrange
        var book = new Book(1, "Clean Code", "Robert C. Martin");
        var member = new StudentMember(1, "Mary");
        var loan = new Loan(book, member, 14);

        // Act
        bool result = loan.IsOverdue();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsOverdue_ReturnedLoan_ReturnsFalse()
    {
        // Arrange
        var book = new Book(1, "Clean Code", "Robert C. Martin");
        var member = new StudentMember(1, "Mary");
        var loan = new Loan(book, member, 14);

        loan.MarkAsReturned();

        // Act
        bool result = loan.IsOverdue();

        // Assert
        Assert.False(result);
    }
}
