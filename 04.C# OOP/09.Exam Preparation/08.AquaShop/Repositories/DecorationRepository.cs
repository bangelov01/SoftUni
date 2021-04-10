using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> models;

        public DecorationRepository()
        {
            models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model)
        {
            models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            var needed = this.models.FirstOrDefault(m => m.GetType().Name == type);
            if (needed == null)
            {
                return null;
            }

            return needed;
        }

        public bool Remove(IDecoration model)
        {
            if (!this.models.Contains(model))
            {
                return false;
            }

            this.models.Remove(model);

            return true;
        }
    }
}
