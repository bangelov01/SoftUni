using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> DbSet;

        public DriverRepository()
        {
            DbSet = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            DbSet.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return DbSet.AsReadOnly();
        }

        public IDriver GetByName(string name)
        {
            IDriver result = DbSet.Find(x => x.Name == name);

            return result;
        }

        public bool Remove(IDriver model)
        {
            if (DbSet.Contains(model))
            {
                DbSet.Remove(model);

                return true;
            }

            return false;
        }
    }
}
