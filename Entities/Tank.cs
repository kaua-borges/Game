using Game.Enums;

namespace Game.Entities
{
    internal class Tank : Personagem
    {
        public Level ShieldPower { get; set; }
        public Level ArmorRating { get; set; }

        public Tank(string name, Level shieldPower, Level armorRating) : base(name, 5000, 30, 1000)
        {
            ShieldPower = shieldPower;
            ArmorRating = armorRating;
        }

        //shield bash based on defense size
        public int ShieldBash()
        {
            switch (ShieldPower)
            {
                case Level.Nivel1:
                    return (Defense * 3) + ((int)ShieldPower * 1);

                case Level.Nivel2:
                    return (Defense * 3) + ((int)ShieldPower * 2);

                case Level.Nivel3:
                    return (Defense * 3) + ((int)ShieldPower * 3);

                default:
                    return 0;
            }
        }

        //Protects against some of the damage taken by the ally.
        public int ProtectAlly(int DamageTakenByAlly)
        {
            switch (ArmorRating)
            {
                case Level.Nivel1:
                    //if the result is negative, the shield's protection is greater—return zero; if the result is positive, the shield failed to contain the damage, so that damage is dealt to the tank instead
                    int result = (DamageTakenByAlly - 300 <= 0) ? (0) : (DamageTakenByAlly - 300);
                    return result;

                case Level.Nivel2:
                    int result0 = (DamageTakenByAlly - 400 <= 0) ? (0) : (DamageTakenByAlly - 400);
                    return result0;
                    
                case Level.Nivel3:
                    int result1 = (DamageTakenByAlly - 500 <= 0) ? (0) : (DamageTakenByAlly - 500);
                    return result1;
                default:
                    return 0;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"level of shield:{ShieldPower.ToString()}, level of armor: {ArmorRating.ToString()}";
        }
    }
}
