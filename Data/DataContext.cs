using Microsoft.EntityFrameworkCore;
using ORA_API.Models.Auth;

namespace ORA_API.Data;

public class DataContext : DbContext
{
    // Auth
    public DbSet<User> Users { get; set; }
    public DbSet<EmailVerification> EmailVerifications { get; set; }
    public DbSet<PasswordVerification> PasswordVerifications { get; set; }

    // 

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
}