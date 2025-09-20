using SBoard.Common.Entities;

namespace SBoard.Models.Auth;

public class User : BaseEntity
{
    public string Username { get; set; }

    // Relations
    public List<PasswordVerification> PasswordVerifications { get; set; } = new List<PasswordVerification>();
    public List<EmailVerification> EmailVerifications { get; set; } = new List<EmailVerification>();
}