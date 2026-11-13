using Game.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Entities
{
    internal class Monk : Personagem
    {
        public Level Prayer { get; set; }
        public Level Revenge { get; set; }

        //O monge nao possui dano de ataque
        public Monk(string name, int defense, Level prayer, Level revenge, int lifePoints) : base(name, lifePoints, 0, defense)
        {
            Prayer = prayer;
            Revenge = revenge;
        }

        //Habilidade que pega 20% do dano recebido pelo monge e devolve como dano para o inimigo dependendo do nivel de Revenge.
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

        //Habilidade que pega 20% do dano recebido pelo usuario e devolve como cura dependendo do nivel de Prayer.
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
