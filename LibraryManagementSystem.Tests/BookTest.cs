using Xunit;

public class BookTests
{
	[Fact]
	public void Constructor_ValidDetails_CreatesBook()
	{
		// Arrange
		int id = 1;
		string title = "Clean Code";
		string author = "Robert C. Martin";

		// Act
		var book = new Book(id, title, author);

		// Assert
		Assert.Equal(id, book.Id);
		Assert.Equal(title, book.Title);
		Assert.Equal(author, book.Author);
		Assert.True(book.IsAvailable);
	}

	[Fact]
	public void Constructor_InvalidId_ThrowsArgumentException()
	{
		// Arrange, Act & Assert
		Assert.Throws<ArgumentException>(() =>
			new Book(0, "Clean Code", "Robert C. Martin"));
	}

	[Fact]
	public void Constructor_EmptyTitle_ThrowsArgumentException()
	{
		Assert.Throws<ArgumentException>(() =>
			new Book(1, "", "Robert C. Martin"));
	}

	[Fact]
	public void Constructor_EmptyAuthor_ThrowsArgumentException()
	{
		Assert.Throws<ArgumentException>(() =>
			new Book(1, "Clean Code", ""));
	}

	[Fact]
	public void Borrow_AvailableBook_BecomesUnavailable()
	{
		// Arrange
		var book = new Book(1, "Clean Code", "Robert C. Martin");

		// Act
		book.Borrow();

		// Assert
		Assert.False(book.IsAvailable);
	}

	[Fact]
	public void Borrow_AlreadyBorrowedBook_ThrowsInvalidOperationException()
	{
		// Arrange
		var book = new Book(1, "Clean Code", "Robert C. Martin");
		book.Borrow();

		// Act & Assert
		Assert.Throws<InvalidOperationException>(() => book.Borrow());
	}

	[Fact]
	public void Return_BorrowedBook_BecomesAvailable()
	{
		// Arrange
		var book = new Book(1, "Clean Code", "Robert C. Martin");
		book.Borrow();

		// Act
		book.Return();

		// Assert
		Assert.True(book.IsAvailable);
	}

	[Fact]
	public void Return_AlreadyAvailableBook_ThrowsInvalidOperationException()
	{
		// Arrange
		var book = new Book(1, "Clean Code", "Robert C. Martin");

		// Act & Assert
		Assert.Throws<InvalidOperationException>(() => book.Return());
	}
}
