using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Context
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=MSKK-YGBB-LT564\\SQLEXPRESS;Initial Catalog=CoreGitHubProject;Integrated Security=True");
    }
}