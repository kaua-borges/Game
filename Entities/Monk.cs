using Game.Enums;
namespace Game.Entities
{
    internal class Monk : Personagem
    {
        public Level Prayer { get; set; }
        public Level Revenge { get; set; }

        

        //The monk has no attack damage
        public Monk(string name, int defense, Level prayer, Level revenge, int lifePoints) : base(name, lifePoints, 0, defense)
        {
            Prayer = prayer;
            Revenge = revenge;
        }

        //An ability that takes 20% of the damage received by the monk and returns it as damage to the enemy, depending on the level of Revenge.
        public int Avenged(int damageTaken)
        {
            switch(Revenge)
            {
                case Level.Nivel1:

                    return((int)(damageTaken * 0.20) *1);

                case Level.Nivel2:
                    return ((int)(damageTaken * 0.20) * 2);

                case Level.Nivel3:
                    return ((int)(damageTaken * 0.20) * 3);
                default:
                    return 0;
            }
        }

        ////An ability that takes 20% of the damage received by the user and returns it as healing, depending on the Prayer level.
        public int ToPray(int DamageTakenByAlly)
        {
            switch (Prayer)
            {
                case Level.Nivel1:
                    return ((int)(DamageTakenByAlly * 0.20) * 1);

                case Level.Nivel2:
                    return ((int)(DamageTakenByAlly * 0.20) * 2);

                case Level.Nivel3:
                    return ((int)(DamageTakenByAlly * 0.20) * 3);
                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Life cured:{Prayer}, damage revenged{Revenge}";
        }
    }
}
