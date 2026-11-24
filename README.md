# Library Management System

A console-based library management application built with **C#**. It lets librarians manage books, register members, process borrowing and returns, and track due dates, while demonstrating Object-Oriented Programming (OOP) principles.

## Features

- Add and manage books
- Register student and staff members
- View available and borrowed books
- Borrow books and process returns
- Automatically calculate due dates
- Apply different borrowing limits by member type
- Track active, returned and overdue loans
- Validate inputs and prevent invalid operations
- Prevent duplicate book and member IDs

## Technologies Used

- C#

## Running the Tests

The project includes automated tests in the `LibraryManagementSystem.Tests` project.

1. Navigate to the test project directory:

```powershell
cd LibraryManagementSystem.Tests
```

2. Run the tests:

```powershell
dotnet test
```

3. View the test results in the terminal.

You can also run all tests from the solution root without changing folders:

```powershell
dotnet test
```

For more detail in the output, use:

```powershell
dotnet test --verbosity normal
```

### What the tests cover

- Adding books and registering members
- Preventing duplicate book and member IDs
- Borrowing an available book
- Preventing borrowing of unavailable books
- Enforcing student and staff borrowing limits
- Returning books and rejecting invalid returns
- Calculating due dates
- Identifying overdue loans

## Project Structure

```text
LibraryManagementSystem/
│
├── Models/
│   ├── Book.cs
│   ├── Member.cs
│   ├── StudentMember.cs
│   ├── StaffMember.cs
│   └── Loan.cs
│
├── Interfaces/
│   └── IBorrowingPolicy.cs
│
├── Services/
│   └── Library.cs
│
├── Program.cs
├── README.md
└── LibraryManagementSystem.csproj
```

## Class Design

| Class | Responsibility |
|---|---|
| **Book** | Stores ID, title, author and availability. Availability can only change through `Borrow()` and `Return()`. |
| **Member** | Abstract base class holding common member data (ID and name). |
| **StudentMember** | Extends `Member` and implements `IBorrowingPolicy` for students. |
| **StaffMember** | Extends `Member` and implements `IBorrowingPolicy` for staff. |
| **IBorrowingPolicy** | Interface defining the maximum books and borrowing period for a member type. |
| **Loan** | Represents one borrowing transaction: book, member, borrow date, due date and return date. Determines whether it is overdue. |
| **Library** | Service class that manages books, members and loans, and enforces business rules. |
| **Program** | Console interface: shows the menu, reads input and calls `Library` operations. |

## OOP Principles

| Principle | Implementation |
|---|---|
| **Encapsulation** | Book availability and loan return status are protected by private setters and changed only through methods. |
| **Inheritance** | `StudentMember` and `StaffMember` inherit from `Member`. |
| **Polymorphism** | Each member type supplies its own borrowing policy through the same interface. |
| **Abstraction** | The abstract `Member` class and the `IBorrowingPolicy` interface define shared structure and contracts. |


Additional rules:

- Only available books can be borrowed.
- Members cannot exceed their borrowing limit.
- A book that is already on loan cannot be borrowed again.
- Only an active loan can be returned, and only by the member who borrowed it.
- Due dates are calculated automatically from the member's policy.
- An active loan is overdue once its due date has passed.

## Assumptions

1. Each book and member has a unique ID, and each book record represents one physical copy.
2. Students can borrow up to 3 books for 14 days, and Staff up to 5 books for 28 days. These rules are predefined.
3. Due dates are calculated in calendar days from the computer's current date, and a book can only be returned by the member who borrowed it.

## Known Limitations

1. **No Data Persistence:** All data is stored in memory and is lost when the application closes.
2. **No Fines or Reservations:** Overdue books are identified, but no fines are calculated, and members cannot reserve unavailable books.
3. **Fixed Rules and Console Only:** Borrowing limits are hardcoded, and the application has no graphical interface or login system.