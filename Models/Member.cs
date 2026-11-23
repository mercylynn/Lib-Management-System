public  abstract class Member
{
    public int Id { get; }

    public string Name { get; }

    public Member(int id, string name)
    {
        if (id <= 0)
            throw new ArgumentException("Member ID must be positive.");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Member name is required.");

        Id = id;
        Name = name;
    }

}