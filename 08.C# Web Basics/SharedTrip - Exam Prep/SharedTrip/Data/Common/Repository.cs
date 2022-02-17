namespace SharedTrip.Data.Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class Repository : IRepository
    {
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add<T>(T entity)
            where T : class
        {
            DbSet<T>().Add(entity);
        }

        public IQueryable<T> Many<T>() 
            where T : class
        {
            return DbSet<T>().AsQueryable();
        }

        public DbSet<T> Single<T>() 
            where T : class
        {
            return DbSet<T>();
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }

        private DbSet<T> DbSet<T>() 
            where T : class
        {
            return dbContext.Set<T>();
        }
    }
}
