namespace AytamyBackend.Models;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public string ParentPhoneNumber { get; set; } = String.Empty;
    public string Country { get; set; } = String.Empty;
    public string City { get; set; } = String.Empty;
    public string Aspirations { get; set; } = String.Empty;
    public string Hobbies { get; set; } = String.Empty;
    public string Job { get; set; } = String.Empty;
    public string Education { get; set; } = String.Empty;
    public string EducationCertificateUrl { get; set; } = String.Empty;
    public string Nationality { get; set; } = String.Empty;
    public string DateOfBirth { get; set; } = String.Empty;
    public string MotherCertificateUrl { get; set; } = String.Empty;
    public string FatherCertificateUrl { get; set; } = String.Empty;
    public string Gender { get; set; } = String.Empty;
    public int Age { get; set; }
    public string Type { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Warranty { get; set; } = String.Empty;
    public bool IsWarranty { get; set; } = false;
    public bool IsComplete { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}