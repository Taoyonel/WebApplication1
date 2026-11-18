namespace SkillHub.Models;

public class ServiceRequest
{
    public int Id { get; set; }
    public int ListingId { get; set; }
    public int RequesterId { get; set; }
    public string Message { get; set; }
    public string Status { get; set; }     // Pending, Accepted, Declined, Cancelled, Completed
    public DateTime DateSent { get; set; }
}