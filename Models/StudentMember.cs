public class StudentMember : Member, IBorrowingPolicy
{
    public int MaximumBooks => 3;

    public int BorrowingDays => 14;

    public StudentMember(int id, string name): base(id, name)
    {
    }
}