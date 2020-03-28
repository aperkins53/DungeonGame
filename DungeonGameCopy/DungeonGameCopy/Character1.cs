using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGameCopy;

namespace DungeonGameCopy
{
    public class Character1
    {
        public string name;
        public int maxHealth = 20;
        public int currentHealth = 20;
        public int attackValue = 2;
        public bool sword = false;
        public bool gun = false;
        public bool ammo = false;
        public bool shield = false;
        public bool upgradedShield = false;
        public enum Weapons { empty = 0, ammo = 2, sword = 5, gun = 10, shield = 5, upgradedShield = 10 };
        public int monstersKilled;

        public void Character(string _name)
        {
            name = _name;
        }

        public void Attack(Beast monster)
        {
            monster.currentHealth -= attackValue;
            Console.WriteLine($"You have attacked the monster! \nIts health is now {monster.currentHealth}");
        }
    }

    public class Beast
    {
        public string name;
        public int currentHealth;
        public int attackValue;

        public void Creature(string _name, int _health, int _attack)
        {
            name = _name;
            currentHealth = _health;
            attackValue = _attack;
        }

        public void FoundMonster(Character1 character, Beast monster)
        {
            Console.WriteLine("You have found a monster. \nWill you fight? [yes / no]");
            string response = Console.ReadLine().ToLower();
            if (response == "yes")
            {
                Console.WriteLine("Ok... it's your funeral. Let's FIGHT!");
                Battle battle = new Battle();
                battle.Fight(character, monster);
            }
            else if (response == "no")
            {
                Console.WriteLine("Wow... you ran away like a scared child.");
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
        }

        public void Attack(Character1 character)
        {
            if (!character.shield && !character.upgradedShield)
            {
                character.currentHealth -= attackValue;
                Console.WriteLine($"The monster attacked you. Your current health is: {character.currentHealth}");
            }
            else if (character.shield && !character.upgradedShield)
            {
                character.currentHealth -= attackValue - (int)Character1.Weapons.shield;
                Console.WriteLine($"The monster attacked you. Your current health is: {character.currentHealth}");
            }
            else
            {
                character.currentHealth -= attackValue - (int)Character1.Weapons.upgradedShield;
                Console.WriteLine($"The monster attacked you. Your current health is: {character.currentHealth}");
            }
        }
    }
}
