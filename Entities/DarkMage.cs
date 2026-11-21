
namespace Game.Entities
{
    internal class DarkMage : Enemies
    {
        private int _manaPoints;

        public int ManaPoints
        {
            get { return _manaPoints; }

            set
            {
                if(value < 0)
                {
                    throw new InvalidOperationException("Mana points don't be negative.");
                }

                _manaPoints = value;
            }
        }

        public DarkMage(string name) : base(name, 1500, 1800, 300, 1500)
        {
            ManaPoints = 0;
        }
    }
}
