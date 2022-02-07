using Microsoft.EntityFrameworkCore;
using PartyRSVP.Models.PartyRSVP.Models;

namespace PartyRSVP.Models
{
    public class MyContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }


        public Microsoft.EntityFrameworkCore.DbSet<CustomerRespond> CustomerResponds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=HXTNYD3\SQLEXPRESS;Database=RSVP;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerRespond>().ToTable("CustomerResponds");
        }
    }
}
