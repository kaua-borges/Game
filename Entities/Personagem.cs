using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    abstract internal class Personagem
    {
        public string Name { get; set; }
        public int LifePoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public Personagem(string name, int lifePoints, int attack, int defense)
        {
            Name = name;
            LifePoints = lifePoints;
            Attack = attack;
            Defense = defense;
        }

        //Metodo ToString que mostra os dados padroes de todo personagem
        public override string ToString()
        {
            return $"Name:{Name}, Life points:{LifePoints}, Attack:{Attack}, Defense:{Defense}";
        }


       
    }
}
