public class StaffMember : Member, IBorrowingPolicy
{
    public int MaximumBooks => 5;

    public int BorrowingDays => 28;

    public StaffMember(int id, string name) : base(id, name)
    {
    }
}