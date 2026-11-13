using Game.Enums;
using System;
using System.Collections.Generic;
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
    }
}
