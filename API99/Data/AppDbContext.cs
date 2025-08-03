using Microsoft.EntityFrameworkCore;
using API99.Models;

namespace API99.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}
