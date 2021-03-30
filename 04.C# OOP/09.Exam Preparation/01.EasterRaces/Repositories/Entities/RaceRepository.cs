using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> DbSet;

        public RaceRepository()
        {
            DbSet = new List<IRace>();
        }

        public void Add(IRace model)
        {
            DbSet.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return DbSet.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            IRace result = DbSet.Find(x => x.Name == name);

            return result;
        }

        public bool Remove(IRace model)
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
