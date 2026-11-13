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

        public Tank(string name, Level shieldPower, Level armorRating) : base(name, 2000, 200, 1000)
        {
            ShieldPower = shieldPower;
            ArmorRating = armorRating;
        }

        public int ShieldBash
    }
}
