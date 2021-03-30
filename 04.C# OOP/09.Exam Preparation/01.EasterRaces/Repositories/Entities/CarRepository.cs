using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> DbSet;

        public CarRepository()
        {
            DbSet = new List<ICar>();
        }

        public void Add(ICar model)
        {
            DbSet.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return DbSet.AsReadOnly();
        }

        public ICar GetByName(string name)
        {
            ICar result = DbSet.Find(x => x.Model == name);

            return result;
        }

        public bool Remove(ICar model)
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
