
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
                    throw new ArgumentException("Mana points don't be negative.");
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

            int TotalDamage = Attack + (int)(ManaPoints * 1.5);

            ManaPoints -= ManaCost;

            return TotalDamage;
        }

        public bool CanUseArcaneBlast() => ManaPoints >= ManaCost;
    }
}
