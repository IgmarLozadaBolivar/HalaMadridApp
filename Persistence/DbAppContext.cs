using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Persistence;

public class DbAppContext : DbContext
{
    public DbAppContext(DbContextOptions<DbAppContext> options) : base(options)
    {}
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}