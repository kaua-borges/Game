
namespace Game.Entities
{
    internal class DarkMage : Enemies
    {
        private int _manaPoints;
        private const int ManaCost = 200;
        public int ManaPoints
        {
            get { return _manaPoints; }

            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Mana cannot be negative.");
                }

                _manaPoints = value;
            }
        }

        public DarkMage(string name) : base(name, 1500, 1800, 300, 1500)
        {
            ManaPoints = 1000;
        }

        public int ArcaneBlast()
        {
            if(ManaPoints < ManaCost)
            {
                throw new InvalidOperationException($"Cost of the mana is {ManaCost} and the quantity of the mana is {ManaPoints} that's it caused an error");
            }

            int totalDamage = Attack + (int)(ManaCost * 1.5);

            ManaPoints -= ManaCost;

            return totalDamage;
        }

        public bool CanUseArcaneBlast() => ManaPoints >= ManaCost;

        public int RegenerateMana()
        {
            int amount = 100;

            return ManaPoints += amount;
        }

        public override string ToString()
        {
            return base.ToString() + $"Mana points: {ManaPoints}";
        }
        
    }
}
