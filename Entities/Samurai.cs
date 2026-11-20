using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    internal class Samurai : Personagem
    {
        public int Dexterity { get; set; }
        public int BowDamage { get; set; }

        public Samurai(string name, int lifePoints, int attack, int defense, int dexterity) : base(name, lifePoints, attack, defense)
        {
            Dexterity = dexterity;
            BowDamage = 20;
        }

        //The higher the Dex, the greater the damage, which is then multiplied by the bow's damage.
        public int RangedAttack()
        {
            if(Dexterity <= 25)
            {
               return (BowDamage * Dexterity);
            }

            else
            {
                //Once Dex exceeds 25, the damage multiplier caps at 40
                return (BowDamage * 40);
            }
        }

        //The sword attack is the base attack plus 50% of your DEX.
        public int MeleeAttack()
        {
            return Attack + ((int)(Dexterity * 0.50));
        }

        //Here, ToString handles the class-specific properties.
        public override string ToString()
        {
            return base.ToString() + $"dexterity:{Dexterity}, bow damage:{BowDamage}";
        }
    }
}
