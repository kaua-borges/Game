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
        

        //Quanto maior a dex maior o dano multiplicado pelo dano do arco.
        public int RangedAttack()
        {
            if(Dexterity <= 25)
            {
               return (BowDamage * Dexterity);
            }

            else
            {
                //A dex passando de 25 o multiplicador do dano trava em 40
                return (BowDamage * 40);
            }
        }


        //O ataque com espada eh o ataque mais 50% da dex.
        public int MeleeAttack()
        {
            return Attack + ((int)(Dexterity * 0.50));
        }

        //Aqui o ToString trata das propriedades especificas da classe.
        public override string ToString()
        {
            return base.ToString() + $"dexterity:{Dexterity}, bow damage:{BowDamage}";
        }
    }
}
