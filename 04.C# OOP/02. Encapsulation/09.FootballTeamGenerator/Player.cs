using System;
using System.Collections.Generic;
using System.Text;

namespace _03.FootballTeamGenerator
{
    public class Player
    {
        private int maxStat = 100;
        private int minStat = 0;
        private string name;
        private decimal endurance;
        private decimal sprint;
        private decimal dribble;
        private decimal passing;
        private decimal shooting;

        public Player(string name, decimal endurance, decimal sprint, decimal dribble, decimal passing, decimal shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            set
            {
                Validator.IfIsNullEmptyOrWhiteSpace(value, "A name should not be empty.");

                this.name = value;
            }
        }
        public decimal Endurance 
        {
            get => this.endurance;
            private set
            {
                Validator.IfInBetweenMinMaxValue(value, $"{nameof(Endurance)} should be between 0 and 100.", minStat, maxStat);

                this.endurance = value;
            } 
        }

        public decimal Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.IfInBetweenMinMaxValue(value, $"{nameof(Sprint)} should be between 0 and 100.", minStat, maxStat);

                this.sprint = value;
            }
        }

        public decimal Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.IfInBetweenMinMaxValue(value, $"{nameof(Dribble)} should be between 0 and 100.", minStat, maxStat);

                this.dribble = value;
            }
        }

        public decimal Passing
        {
            get => this.passing;
            private set
            {
                Validator.IfInBetweenMinMaxValue(value, $"{nameof(Passing)} should be between 0 and 100.", minStat, maxStat);

                this.passing = value;
            }
        }

        public decimal Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.IfInBetweenMinMaxValue(value, $"{nameof(Shooting)} should be between 0 and 100.", minStat, maxStat);

                this.shooting = value;
            }
        }

        public decimal GetSkillLevel()
        {
            return (Endurance + Sprint + Shooting + Passing + Dribble) / 5;
        }
    }
}
