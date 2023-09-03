using Microsoft.EntityFrameworkCore;
using MovieForm.DataAcces.Entities;

namespace MovieForm.DataAcces.DbContexts
{
    public class MovieDbContext:DbContext
    {

        public MovieDbContext()
        {

        }

        public MovieDbContext(DbContextOptions<MovieDbContext> options):base(options)
        {
         
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MovieDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Movie> Movies { get; set; }


    }
}
