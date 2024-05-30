namespace Domain.Entities;

public class Account
{
    public Guid IdAccount { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsEmailVerified { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid UpdatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid? IdPhoto { get; set; }
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
    public Receptionist Receptionist { get; set; }
}