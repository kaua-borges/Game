namespace Game.Entities
{
    internal class ForgeExecutioner : Enemies
    {
        public int RagePoints
        {
            get { return _ragePoints; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Rage points do not have negatives values.");
                }

                _ragePoints = value;
            }
        }
        
        private int _ragePoints;

        private const int MinRageforCrushingBlow = 200;

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
            if(RagePoints < MinRageforCrushingBlow)
            {
                throw new InvalidOperationException($"Minimum rage required is {MinRageforCrushingBlow}, but current rage is {RagePoints}");
            }

            int totalDamage = RagePoints - (int)(RagePoints * 0.40) + Attack;
            RagePoints = 0;
            return totalDamage;
        }

        public override string ToString()
        {
            return base.ToString() + $"rage point value:{RagePoints}";
        }

        public bool CanUseCrushingBlow() => RagePoints >= MinRageforCrushingBlow;
    }
}
