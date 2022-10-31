using Microsoft.EntityFrameworkCore;
using OData.Demo.Data.Entities;

namespace OData.Demo.Data
{
    public class MyWorldDbContext : DbContext
    {
        public MyWorldDbContext(DbContextOptions<MyWorldDbContext> options) : base(options)
        {

        }
        public DbSet<Gadgets> Gadgets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // below line to watch the ef core sql quiries generation
            // not at all recomonded for the production code
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
