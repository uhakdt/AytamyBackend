namespace AytamyBackend.Models;

public class User
{
    public int userID { get; set; }
    public string name { get; set; } = String.Empty;
    public string email { get; set; } = String.Empty;
    public string phone { get; set; } = String.Empty;
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}  