using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameCopy
{
    public class Character
    {
        public bool isAlive = true;
        public string name;
        public char roomLocation;
        public int maxHealth = 20;
        public int currentHealth;
        public int attackValue;
        public int sword = 5;
        public int gun = 15;
        public bool hasShield = false;
        public bool hasSword = false;
        public bool key1 = false;
        public bool hasAmmo = false;
        public bool hasGun = false;
        public bool hasUS = false;
        public bool validOptionChoice = false;

        public Character(string _name, int _health, int _attackValue)
        {
            name = _name;
            currentHealth = _health;
            maxHealth = _health;
            attackValue = _attackValue;
        }

        public void Attack(Monster target)
        {
            while (currentHealth > 0 && target.currentHealth > 0)
            {
                while (!validOptionChoice)
                { 
                    if (hasGun)
                    {
                        Console.WriteLine("Press 1 to use your sword or 2 to use your gun!");
                        int attackChoice = Convert.ToInt32(Console.ReadLine());
                        if (attackChoice == 1)
                        {
                            attackValue = sword;
                            target.currentHealth -= attackValue;
                            validOptionChoice = true;
                        }
                        else if (attackChoice == 2)
                        {
                            attackValue = gun;
                            target.currentHealth -= attackValue;
                            validOptionChoice = true;     
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Press 1 to use your sword");
                        int attackChoice = Convert.ToInt32(Console.ReadLine());
                        if (attackChoice == 1)
                        {
                            attackValue = sword;
                            target.currentHealth -= attackValue;
                            validOptionChoice = true;
                        }
                    }
                }
                validOptionChoice = false;

                if (currentHealth > 0 && target.currentHealth > 0)
                {
                    Console.WriteLine($"Monster health is {target.currentHealth}/{target.maxHealth}.\n");
                }
                else if (currentHealth <= 0 && target.currentHealth > 0)
                {
                    Console.WriteLine("You were killed by the monster!");
                    isAlive = false;
                }
                else
                {
                    Console.WriteLine("You killed the monster!");
                    target.isAlive = false;
                }
                break;
            }
        }
    }

    public class Monster
    {
        public bool isAlive = true;
        public string name;
        public int maxHealth;
        public int currentHealth;
        public int attackValue;

        public Monster(string _name, int _health, int _attackValue)
        {
            name = _name;
            currentHealth = _health;
            maxHealth = _health;
            attackValue = _attackValue;
        }

        public void Attack(Character target)
        {
            while (target.currentHealth > 0 && currentHealth > 0)
            {
                if (target.hasShield && !target.hasUS)
                {
                    Random rand = new Random();
                    Console.WriteLine("Monster attacks!");
                    int damage = rand.Next(0, attackValue + 1);
                    target.currentHealth -= damage;
                    Console.WriteLine($"User health is {target.currentHealth}/{target.maxHealth}.\n");
                    break;
                }
                else if (target.hasUS)
                {
                    Random rand = new Random();
                    Console.WriteLine("Monster attacks!");
                    int damage = rand.Next(0, attackValue + 1);
                    target.currentHealth -= (damage/2);
                    Console.WriteLine($"User health is {target.currentHealth}/{target.maxHealth}.\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Monster attacks!");
                    target.currentHealth -= attackValue;
                    Console.WriteLine($"User health is {target.currentHealth}/{target.maxHealth}.\n");
                    break;
                }
            }

            if (currentHealth <=0)
            {
                Console.WriteLine("The monster dropped a health potion and a key.");
                target.currentHealth = target.maxHealth;
                Console.WriteLine($"Your health is now: {target.currentHealth}/{target.maxHealth}.");
            }
        }

        public void FoundMonster()
        {
            Console.WriteLine("\nYou have found a monster. \nFight? [yes or no]");
        }
    }

    public class ValidOption
    {
        public void Valid()
        {
            Console.WriteLine("\nPlease enter a valid option");
        }
    }
}
