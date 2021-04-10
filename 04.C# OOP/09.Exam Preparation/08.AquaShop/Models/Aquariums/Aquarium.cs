using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorationsCollection;
        private List<IFish> fishCollection;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            decorationsCollection = new List<IDecoration>();
            fishCollection = new List<IFish>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }


        public int Capacity { get; private set; }

        public int Comfort => CalculateComfort();

        public ICollection<IDecoration> Decorations => this.decorationsCollection.AsReadOnly();

        public ICollection<IFish> Fish => this.fishCollection.AsReadOnly();

        public void AddDecoration(IDecoration decoration)
        {
            this.decorationsCollection.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fishCollection.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            fishCollection.Add(fish);
        }

        public void Feed()
        {
            foreach (var fish in fishCollection)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            string fishExist = "none";

            if (this.fishCollection.Any())
            {
                fishExist = string.Join(", ", fishCollection.Select(f => f.Name).ToArray()); // CHECK!!
            }

            sb.AppendLine($"Fish: {fishExist}");
            sb.AppendLine($"Decorations: {decorationsCollection.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            if (!this.fishCollection.Contains(fish))
            {
                return false;
            }

            this.fishCollection.Remove(fish);
            return true;
        }

        private int CalculateComfort()
        {
            var result = decorationsCollection.Sum(d => d.Comfort);

            return result;
        }
    }
}
