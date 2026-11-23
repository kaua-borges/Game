using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    internal class Enemies
    {
        public string Name { get; set; }
        public int LifePoints { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MagicDefense { get; set; }

        public Enemies(string name, int lifePoints, int attack, int defense, int magicDefense)
        {
            Name = name;
            LifePoints = lifePoints;
            Attack = attack;
            Defense = defense;
            MagicDefense = magicDefense;
        }

        public override string ToString()
        {
            return $"name:{Name}, points of life:{LifePoints}, attack:{Attack}, defense:{Defense}, magic defense:{MagicDefense}";
        }

        public bool HasAliveEnemies()
        {
            if(LifePoints <= 0)
            {
                Console.WriteLine($"{Name} don't has enough life.");
                return false;
            }

            bool HasEnoughLife = LifePoints > 0;
            return HasEnoughLife;
        }
    }
}
