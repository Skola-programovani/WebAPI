using Microsoft.EntityFrameworkCore;
namespace TodoApi.Models
{
    public class MyContext : DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=70.37.108.236;database=prg_dbbackup;uid=TestUser;pwd=123456;");
    }
    
        public DbSet<Admin> Admin { get; set; }
    }
}