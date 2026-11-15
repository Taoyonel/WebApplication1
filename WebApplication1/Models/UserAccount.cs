namespace SkillHub.Models;

public class UserAccount
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }       // "Admin", "Professional", or "Regular"
    public string Location { get; set; }
    public string Bio { get; set; }

    public string GetInitial()
    {
        return FullName.Substring(0, 1).ToUpper();
    }
}