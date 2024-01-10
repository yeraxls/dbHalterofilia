using db.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace db
{
    public class WeightliftingContext : DbContext
    {
        public WeightliftingContext(DbContextOptions<WeightliftingContext> options)
        : base(options)
        { }
        public DbSet<Competitor> Competitors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<TypeLifting> TypeLiftings { get; set; }
        public DbSet<LiftingWeight> LiftingWeight { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Logs> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competitor>().ToTable("Competitor");
            modelBuilder.Entity<Country>().ToTable("Country");
            modelBuilder.Entity<TypeLifting>().ToTable("TypeLifting");
            modelBuilder.Entity<LiftingWeight>().ToTable("LiftingWeight");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Logs>().ToTable("Logs");
        }

        public async Task<T> Insert<T>(T elemento) where T : class
        {
            await AddAsync<T>(elemento);
            return elemento;
        }

        public async Task SaveAll()
        {
            await SaveChangesAsync();
        }

        public void Delete<T>(T elemento) where T : class
        {
            Remove<T>(elemento);
        }
        public IQueryable<T> Queryable<T>(Expression<Func<T, bool>> expression = null) where T : class
        {
            if (expression == null)
                return Set<T>();
            return Set<T>().Where(expression);
        }
    }
}