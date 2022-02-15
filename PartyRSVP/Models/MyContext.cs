using Microsoft.EntityFrameworkCore;


namespace PartyRSVP.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }


        public DbSet<CustomerRespond> CustomerResponds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }
    }
}
