using Game.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Game.Services
{
    class BattleService
    {
        public List<Personagem> Heroes = new List<Personagem>();
        public List<Enemies> Enemies = new List<Enemies>();
        private Personagem? _protectedAlly;
        private Tank? _protectingTank;

        private Personagem ChooseTarget(List<Personagem> heroes)
        {
            List<Personagem> aliveTargets = heroes.Where(h => h.LifePoints > 0).ToList();

            Console.WriteLine("Choose a hero target:");
            for (int i = 0; i < aliveTargets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {aliveTargets[i].Name} (HP: {aliveTargets[i].LifePoints})");
            }

            while (true)
            {
                Console.Write("Target number: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= aliveTargets.Count)
                {
                    return aliveTargets[choice - 1];
                }

                Console.WriteLine($"Invalid option. Choose a number between 1 and {aliveTargets.Count}.");
            }
        }

        private Enemies ChooseTarget(List<Enemies> enemies)
        {
            List<Enemies> aliveTargets = enemies.Where(e => e.LifePoints > 0).ToList();

            Console.WriteLine("Choose an enemy target:");
            for (int i = 0; i < aliveTargets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {aliveTargets[i].Name} (HP: {aliveTargets[i].LifePoints})");
            }

            while (true)
            {
                Console.Write("Target number: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 1 && choice <= aliveTargets.Count)
                {
                    return aliveTargets[choice - 1];
                }

                Console.WriteLine($"Invalid option. Choose a number between 1 and {aliveTargets.Count}.");
            }
        }

        public bool HasAliveHeroes() => Heroes.Any(hero => hero.LifePoints > 0);

        public bool HasAliveEnemies() => Enemies.Any(enemy => enemy.LifePoints > 0);

        private void ApplyDamage(Personagem target, int damage)
        {
            int baseDamage = Math.Max(0, damage);
            int finalDamage = Math.Max(0, baseDamage - target.Defense);

            target.LifePoints -= finalDamage;
            if (target.LifePoints < 0)
            {
                target.LifePoints = 0;
            }

            Console.WriteLine($"{target.Name} took {finalDamage} damage! (Remaining HP: {target.LifePoints})");
        }

        private void ApplyDamage(Enemies target, int damage, bool isMagicDamage = false)
        {
            int baseDamage = Math.Max(0, damage);
            int defense = isMagicDamage ? target.MagicDefense : target.Defense;
            int finalDamage = Math.Max(0, baseDamage - defense);

            target.LifePoints -= finalDamage;
            if (target.LifePoints < 0)
            {
                target.LifePoints = 0;
            }

            if (target is ForgeExecutioner executioner && finalDamage > 0)
            {
                executioner.IncrementRagePoints(finalDamage);
            }

            Console.WriteLine($"{target.Name} took {finalDamage} damage! (Remaining HP: {target.LifePoints})");
        }
        private int ReadChoice(int min, int max)
        {
            while (true)
            {
                Console.Write($"Choose ({min}-{max}): ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }

                Console.WriteLine($"Invalid option. Enter a number between {min} and {max}.");
            }
        }

        private int ReadNonNegativeInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value >= 0)
                {
                    return value;
                }

                Console.WriteLine("Invalid number. Enter 0 or greater.");
            }
        }
        private void ExecuteHeroesTurn()
        {
            foreach (Personagem hero in Heroes)
            {
                if (hero.LifePoints <= 0)
                {
                    continue;
                }

                if (!HasAliveEnemies())
                {
                    break;
                }

                Console.WriteLine($"\n--- {hero.Name}'s Turn ---");

                switch (hero)
                {
                    case Tank tank:
                        Console.WriteLine("1. Shield Bash");
                        Console.WriteLine("2. Protect Ally (mitigate incoming damage for an ally)");
                        int tankChoice = ReadChoice(1, 2);

                        if (tankChoice == 1)
                        {
                            Enemies target = ChooseTarget(Enemies);
                            ApplyDamage(target, tank.ShieldBash());
                        }
                        else
                        {
                            Personagem ally = ChooseTarget(Heroes);
                            _protectedAlly = ally;
                            _protectingTank = tank;
                            Console.WriteLine($"{tank.Name} is now protecting {ally.Name}");
                        }
                        break;

                    case Samurai samurai:
                        Console.WriteLine("1. Melee Attack");
                        Console.WriteLine("2. Ranged Attack");
                        int samuraiChoice = ReadChoice(1, 2);

                        Enemies samuraiTarget = ChooseTarget(Enemies);
                        int samuraiDamage = samuraiChoice == 1 ? samurai.MeleeAttack() : samurai.RangedAttack();
                        ApplyDamage(samuraiTarget, samuraiDamage);
                        break;

                    case Monk monk:
                        Console.WriteLine("1. To Pray (heal an ally based on reference damage)");
                        Console.WriteLine("2. Avenged (vengeance damage to an enemy based on damage taken)");
                        int monkChoice = ReadChoice(1, 2);

                        Console.Write("Reference damage value: ");
                        int refDamage = ReadNonNegativeInt();

                        if (monkChoice == 1)
                        {
                            Personagem allyToHeal = ChooseTarget(Heroes);
                            int healAmount = monk.ToPray(refDamage);
                            allyToHeal.LifePoints += healAmount;
                            Console.WriteLine($"{monk.Name} prayed for {allyToHeal.Name} and restored {healAmount} HP! (Current HP: {allyToHeal.LifePoints})");
                        }
                        else
                        {
                            Enemies enemyToAvenge = ChooseTarget(Enemies);
                            int revengeDamage = monk.Avenged(refDamage);
                            ApplyDamage(enemyToAvenge, revengeDamage);
                        }
                        break;
                }
            }
        }

        private void DealDamageTohero(Personagem target, int rawDamage)
        {
            if (_protectedAlly != null && _protectingTank != null && target == _protectedAlly && _protectingTank.LifePoints > 0)
            {
                int DamageTaken = _protectingTank.ProtectAlly(rawDamage);
                ApplyDamage(_protectingTank, DamageTaken);
                Console.WriteLine($"{_protectingTank.Name} protected {target.Name}!");
                _protectingTank = null;
                _protectedAlly = null;
                return;
            }

            ApplyDamage(target, rawDamage);
        }

        private void ExecuteEnemiesTurn()
        {
            foreach (Enemies enemy in Enemies)
            {
                if (enemy.LifePoints <= 0)
                {
                    continue;
                }

                if (!HasAliveHeroes())
                {
                    break;
                }

                Console.WriteLine($"\n--- {enemy.Name}'s Turn ---");

                switch (enemy)
                {
                    case DarkMage darkMage:
                        Console.WriteLine("1. Basic Attack");
                        Console.WriteLine($"2. Arcane Blast (Mana: {darkMage.ManaPoints})");
                        Console.WriteLine($"3. Regenerate Mana (Mana: {darkMage.ManaPoints})");
                        int mageChoice = ReadChoice(1, 3);

                        if (mageChoice == 1)
                        {
                            Personagem target = ChooseTarget(Heroes);
                            DealDamageTohero(target, darkMage.Attack);
                        }
                        else if (mageChoice == 2)
                        {
                            if (!darkMage.CanUseArcaneBlast())
                            {
                                Console.WriteLine("Not enough mana for Arcane Blast! Performing Basic Attack instead.");
                                Personagem target = ChooseTarget(Heroes);
                                DealDamageTohero(target, darkMage.Attack);
                                break;
                            }

                            try
                            {
                                int blastDamage = darkMage.ArcaneBlast();
                                Console.WriteLine("Choose a target for Arcane Blast (against enemy magic/physical rules):");
                                Personagem target = ChooseTarget(Heroes);
                                DealDamageTohero(target, blastDamage);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            int newMana = darkMage.RegenerateMana();
                            Console.WriteLine($"{darkMage.Name} regenerated mana! Current Mana: {newMana}");
                        }
                        break;

                    case ForgeExecutioner executioner:
                        Console.WriteLine("1. Basic Attack");
                        Console.WriteLine($"2. Crushing Blow (Rage: {executioner.RagePoints})");
                        int execChoice = ReadChoice(1, 2);

                        if (execChoice == 1)
                        {
                            Personagem target = ChooseTarget(Heroes);
                            DealDamageTohero(target, executioner.Attack);
                        }
                        else
                        {
                            if (!executioner.CanUseCrushingBlow())
                            {
                                Console.WriteLine("Not enough rage for Crushing Blow! Performing Basic Attack instead.");
                                Personagem target = ChooseTarget(Heroes);
                                DealDamageTohero(target, executioner.Attack);
                                break;
                            }

                            try
                            {
                                int crushingDamage = executioner.CrushingBlow();
                                Personagem target = ChooseTarget(Heroes);
                                DealDamageTohero(target, crushingDamage);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                }
            }

        }
        public void StartBattle()
        {
            int round = 1;

            while (HasAliveHeroes() && HasAliveEnemies())
            {
                Console.WriteLine($"\n================ ROUND {round} ================");
                ExecuteHeroesTurn();

                if (!HasAliveEnemies())
                {
                    break;
                }

                ExecuteEnemiesTurn();

                // Garante que a proteção do Tank não vaze para a próxima rodada caso ninguém ataque o aliado protegido
                _protectedAlly = null;
                _protectingTank = null;

                round++;
            }

            Console.WriteLine("\n================ BATTLE OVER ================");
            if (HasAliveHeroes())
            {
                Console.WriteLine("Victory! The heroes defeated all enemies!");
            }
            else
            {
                Console.WriteLine("Defeat! All heroes have fallen.");
            }
        }
    }
}
 