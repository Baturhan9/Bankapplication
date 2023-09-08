using MyOwnBank.Models;
using Microsoft.EntityFrameworkCore;

namespace MyOwnBank.Data;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions options) : base(options)
    {
        
    }
    public DbSet<Client> Clients { get; set; }
    public DbSet<BankCard> BankCards{ get; set; }
}