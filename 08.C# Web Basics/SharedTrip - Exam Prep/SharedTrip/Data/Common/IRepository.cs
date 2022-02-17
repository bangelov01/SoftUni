namespace SharedTrip.Data.Common
{
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public interface IRepository
    {
        void Add<T>(T entity)
            where T : class;

        IQueryable<T> Many<T>()
            where T : class;

        DbSet<T> Single<T>()
            where T : class;

        int SaveChanges();
    }
}
