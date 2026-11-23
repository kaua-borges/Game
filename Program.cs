using Game.Entities; // ajuste para o namespace onde estão Personagem, Tank, Samurai, Monk, Enemies, DarkMage, ForgeExecutioner e Level
using Game.Enums;
using Game.Services;
using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BattleService battleService = new BattleService();

            // Instanciando os Heróis (ajuste os argumentos do construtor conforme a ordem definida nas suas classes)
            Tank tank = new Tank("Aegis", Level.Nivel2, Level.Nivel2);
            Samurai samurai = new Samurai("Kenshin", 3000, 2000, 1000, 200);
            Monk monk = new Monk("Tenzin", 1000 ,Level.Nivel1, Level.Nivel3, 2000);

            battleService.Heroes.Add(tank);
            battleService.Heroes.Add(samurai);
            battleService.Heroes.Add(monk);

            // Instanciando os Inimigos (ajuste os argumentos conforme o construtor de DarkMage e ForgeExecutioner)
            DarkMage darkMage = new DarkMage("Malakor");
            ForgeExecutioner executioner = new ForgeExecutioner("Brutus");

            battleService.Enemies.Add(darkMage);
            battleService.Enemies.Add(executioner);

            Console.WriteLine("=== STARTING BATTLE ===");
            battleService.StartBattle();
        }
    }
}
