using System;

public class ScoreEntity
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public long Score { get; set; }
    public string Name { get; set; } = "Guest";
}
