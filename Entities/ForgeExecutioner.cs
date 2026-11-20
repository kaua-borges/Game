namespace Game.Entities
{
    internal class ForgeExecutioner : Enemies
    {
        public int RagePoints
        {
            get { return _ragePoints; }

            set
            {
                _ragePoints = value;
                if (value < 0)
                {
                    throw new ArgumentException("Rage points do not have negatives values.");
                }
            }
        }

        private int _ragePoints;

        public ForgeExecutioner(string name) : base(name, 3000, 2000, 1000, 20)
        {
            RagePoints = 0;
        }

        
        public int IncrementRagePoints(int damageTaken)
        {
            return RagePoints = damageTaken + RagePoints;
        }

        public int CrushingBlow()
        {
            int totalDamage = RagePoints - (int)(RagePoints * 0.40) + Attack;
            RagePoints = 0;
            return totalDamage;
        }

        public override string ToString()
        {
            return base.ToString() + $"rage point value:{RagePoints}";
        }
    }
}
