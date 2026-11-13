using Game.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Game.Entities
{
    internal class Tank : Personagem
    {
        public Level ShieldPower { get; set; }
        public Level ArmorRating { get; set; }

        public Tank(string name, Level shieldPower, Level armorRating) : base(name, 2000, 30, 1000)
        {
            ShieldPower = shieldPower;
            ArmorRating = armorRating;
        }

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

        public int ProtectAlly(int DamageTakenByAlly)
        {
            switch (ArmorRating)
            {
                case Level.Nivel1:
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
    }
}
