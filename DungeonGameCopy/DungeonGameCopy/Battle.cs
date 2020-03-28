using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGameCopy
{
    class Battle
    {
        public void Fight(Character1 character, Beast monster)
        {
            Console.WriteLine("Press any key to use your sword?");
            Console.ReadLine();
            character.attackValue = 5;
            while (character.currentHealth > 0 && monster.currentHealth > 0)
            {
                character.Attack(monster);
                monster.Attack(character);
            }
            if (character.currentHealth <= 0)
            {
                Console.WriteLine("You have been killed... \nGAME OVER.");
            }
            else if (monster.currentHealth <= 0)
            {
                character.currentHealth = character.maxHealth;
                Console.WriteLine("You have killed the monster!" +
                    $"\nThe monster dropped a potion. Your health is now back to {character.currentHealth}/{character.maxHealth}" +
                    "\nYou also found a key");
            }
        }
    }
}
