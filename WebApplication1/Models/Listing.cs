namespace SkillHub.Models;

public class Listing
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }       // "Tutor" or "Service"
    public decimal HourlyRate { get; set; }
    public double Rating { get; set; }
    public bool IsActive { get; set; }
}