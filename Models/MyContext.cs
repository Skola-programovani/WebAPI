using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
namespace TodoApi.Models
{
    public class MyContext : DbContext
    {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=40.68.130.54;database=prgbackup;uid=dbAdmin;pwd=Pepa123456!;");
    }
    
        public DbSet<Admin> Admin { get; set; }
    
        public DbSet<TodoApi.Models.Klient> Klient { get; set; }
    
        public DbSet<TodoApi.Models.Path> Path { get; set; }
    
        public DbSet<TodoApi.Models.Report> Report { get; set; }
    
        public DbSet<TodoApi.Models.Template> Template { get; set; }
    
        public DbSet<TodoApi.Models.TemplateLink> TemplateLink { get; set; }
    }
}