
using Xunit;

public class MemberTests
{
    [Fact]
    public void StudentMember_ValidDetails_CreatesStudent()
    {
        // Arrange
        int id = 1;
        string name = "Mary";

        // Act
        var student = new StudentMember(id, name);

        // Assert
        Assert.Equal(id, student.Id);
        Assert.Equal(name, student.Name);
    }

    [Fact]
    public void StaffMember_ValidDetails_CreatesStaff()
    {
        // Arrange
        int id = 2;
        string name = "John";

        // Act
        var staff = new StaffMember(id, name);

        // Assert
        Assert.Equal(id, staff.Id);
        Assert.Equal(name, staff.Name);
    }

    [Fact]
    public void StudentMember_MaximumBooks_ReturnsThree()
    {
        // Arrange
        var student = new StudentMember(1, "Mary");

        // Act
        int result = student.MaximumBooks;

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void StudentMember_BorrowingDays_ReturnsFourteen()
    {
        // Arrange
        var student = new StudentMember(1, "Mary");

        // Act
        int result = student.BorrowingDays;

        // Assert
        Assert.Equal(14, result);
    }

    [Fact]
    public void StaffMember_MaximumBooks_ReturnsFive()
    {
        // Arrange
        var staff = new StaffMember(2, "John");

        // Act
        int result = staff.MaximumBooks;

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void StaffMember_BorrowingDays_ReturnsThirty()
    {
        // Arrange
        var staff = new StaffMember(2, "John");

        // Act
        int result = staff.BorrowingDays;

        // Assert
        Assert.Equal(28, result);
    }

    [Fact]
    public void StudentMember_InvalidId_ThrowsArgumentException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new StudentMember(0, "Mary"));
    }

    [Fact]
    public void StaffMember_EmptyName_ThrowsArgumentException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new StaffMember(2, ""));
    }
}
