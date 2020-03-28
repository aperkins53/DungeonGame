using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonGameCopy.Rooms;

namespace DungeonGameCopy
{
    public class DungeonGame : GetawayVehicle
    {
        public bool alreadyRoomB = false;
        public bool alreadyRoomC = false;
        public bool alreadyRoomD = false;
        public bool alreadyRoomE = false;
        public bool alreadyRoomF = false;
        public bool foughtMonster = false;
        public bool foughtMonster2 = false;
        public bool alreadyB2RoomA = false;
        public bool alreadyB2RoomB = false;
        public bool alreadyB2RoomC = false;
        public bool alreadyB2RoomD = false;
        public bool alreadyBuilding3 = false;

        GetawayVehicle escape = new GetawayVehicle();
        Character user = new Character("User", 20, 5);
        Monster monster1 = new Monster("Monster1", 20, 5);
        Monster monster2 = new Monster("Monster2", 30, 10);
        ValidOption validOption = new ValidOption();


        Character1 character = new Character1() { };
        

        public void Run()
        {
            Console.WriteLine("Welcome to the Dungeon, we have fun and games...");
            RoomA();
        }

        public void RoomA()
        {
            Console.WriteLine("\nYou're in room A. \nGo left, right, or down?");
            string response = Console.ReadLine().ToLower();
            if (response == "left")
            {
                RoomB();
            }
            else if (response == "right")
            {
                RoomC();
            }
            else if (response == "down")
            {
                RoomD();
            }
            else
            {
                Console.WriteLine("Please enter a valid option");
                RoomA();
            }
        }
        public void RoomB()
        {
            if (!alreadyRoomB)
            {
                Console.WriteLine("\nYou found a sword!");
                user.hasSword = true;
                alreadyRoomB = true;

                Console.WriteLine("\nYou're in room B. \nGo right or down?");
                string response = Console.ReadLine().ToLower();
                if (response == "down")
                {
                    RoomE();
                }
                else if (response == "right")
                {
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomB();
                }
            }
            else if (alreadyRoomB && !readyToEscape)
            {
                Console.WriteLine("\nYou have already been in room B.\nGo right or down?");
                string response = Console.ReadLine().ToLower();
                if (response == "down")
                {
                    RoomE();
                }
                else if (response == "right")
                {
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomB();
                }
            }
            else if (alreadyRoomB && readyToEscape && !tire1)
            {
                Console.WriteLine("You found tire#1!\n" +
                    "Keep looking for the rest of the parts");
                tire1 = true;
                parts ++;
                if (parts == 6)
                {
                    Finish();
                }
                else
                {
                    RoomB();
                }
            }
            else if (alreadyRoomB && readyToEscape && tire1)
            {
                Console.WriteLine("\nYou have already found the part in room B.\nGo right or down?");
                string response = Console.ReadLine().ToLower();
                if (response == "down")
                {
                    RoomE();
                }
                else if (response == "right")
                {
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomB();
                }
            }
        }
        public void RoomC()
        {
            if (!alreadyRoomC)
            {
                Console.WriteLine("\nYou found a shield!");
                user.hasShield = true;
                alreadyRoomC = true;

                Console.WriteLine("\nYou're in room C. \nGo left?");
                string response = Console.ReadLine().ToLower();
                if (response == "left")
                {
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomC();
                }
            }
            else if (alreadyRoomC && !readyToEscape)
            {
                Console.WriteLine("\nYou have already been in room C.\nGo left?");
                string response = Console.ReadLine().ToLower();
                if (response == "left")
                {
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomC();
                }
            }
            else if (alreadyRoomC && readyToEscape && !tire2)
            {
                Console.WriteLine("\nYou found tire#2!\n" +
                    "Keep looking for the rest of the parts");
                tire2 = true;
                parts++;
                if (parts == 6)
                {
                    Finish();
                }
                else
                {
                    RoomC();
                }
            }
            else if (alreadyRoomC && readyToEscape && tire2)
            {
                Console.WriteLine("\nYou have already found the part in room C.\nGo left?");
                string response = Console.ReadLine().ToLower();
                if (response == "left")
                {
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomC();
                }
            }
        }
        public void RoomD()
        {
            if (user.hasSword && user.hasShield && !foughtMonster)
            {
                monster1.FoundMonster();
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    Console.WriteLine("\nLet's Fight!!!");
                    while (user.isAlive && monster1.isAlive)
                    {
                        user.Attack(monster1);
                        monster1.Attack(user);
                    }
                    foughtMonster = true;
                    alreadyRoomD = true;
                    user.key1 = true;
                    while (!alreadyB2RoomA)
                    {
                        Console.WriteLine("\nWhere would you like to go? \n1: Building 2 \n2: Building 3");
                        string nextResponse = Console.ReadLine();
                        if (nextResponse == "1")
                        {
                            B2RoomA();
                        }
                        else if (nextResponse == "2")
                        {
                            Console.WriteLine("\nYou are not prepared to enter this building, please discover better equipment and then return...");
                        }
                        else
                        {
                            validOption.Valid();
                        }
                    }
                }
                else if (response == "no")
                {
                    Console.WriteLine("\nYou chose not to fight and run like a scared child...");
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomD();
                }
            }
            else if (alreadyRoomD && readyToEscape && !tire3)
            {
                Console.WriteLine("\nYou found tire#3!\n" +
                    "Keep looking for the rest of the parts");
                tire3 = true;
                parts++;
                if (parts == 6)
                {
                    Finish();
                }
                else
                {
                    RoomD();
                }
            }
            else if (alreadyRoomD && readyToEscape && tire3)
            {
                Console.WriteLine("\nYou have already been in room D.\nGo up, left, or down to building 2?");
                string response = Console.ReadLine().ToLower();
                if (response == "left")
                {
                    RoomE();
                }
                else if (response == "up")
                {
                    RoomA();
                }
                else if (response == "down")
                {
                    B2RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomD();
                }
            }
            else if (alreadyRoomD && !readyToEscape)
            {
                Console.WriteLine("\nYou have already been in room D.\nGo up or left?");
                string response = Console.ReadLine().ToLower();
                if (response == "left")
                {
                    RoomE();
                }
                else if (response == "up")
                {
                    RoomA();
                }
                else
                {
                    validOption.Valid();
                    RoomD();
                }
            }
            else
            {
                Console.WriteLine("\nYou cannot go down yet...");
                RoomA();
            }
        }

        public void RoomE()
        {
            Console.WriteLine("\nThis room is empty. \nGo up or right?");
            alreadyRoomE = true;
            string response = Console.ReadLine().ToLower();
            if (response == "right" && user.hasSword && user.hasShield && !foughtMonster)
            {
                RoomD();
            }
            else if (response == "right" && (!user.hasSword || !user.hasShield))
            {
                Console.WriteLine("\nYou cannot go right yet...");
                RoomE();
            }
            else if (response == "up")
            {
                RoomB();
            }
            else
            {
                validOption.Valid();
                RoomE(); 
            }
        }

        public void B2RoomA()
        {
            if (user.key1 == true)
            {
                alreadyB2RoomA = true;
                Console.WriteLine("\nYou are in the first room of the second building.\n" +
                    "Explore and see what you can find.\n" +
                    "You can go left, right, down, or up to go back to the first building.");
                string response = Console.ReadLine().ToLower();
                if (response == "left")
                {
                    B2RoomB();
                }
                else if (response == "down")
                {
                    B2RoomC();
                }
                else if (response == "right")
                {
                    B3();
                }
                else if (response == "up")
                {
                    RoomD();
                }
                else
                {
                    validOption.Valid();
                    B2RoomA();
                }
            }           
        }

        public void B2RoomB()
        {
            if (!alreadyB2RoomB)
            {
                Console.WriteLine("\nYou have found some ammo! \nYou can go right or down.");
                string response = Console.ReadLine();
                alreadyB2RoomB = true;
                user.hasAmmo = true;
                if (response == "right")
                {
                    B2RoomA();
                }
                else if (response == "down")
                {
                    B2RoomD();
                }
                else
                {
                    validOption.Valid();
                    B2RoomB();
                }
            }
            else if (alreadyB2RoomB && !readyToEscape)
            {
                Console.WriteLine("\nThis room is empty. \nYou can go right or down.");
                string response = Console.ReadLine();
                if (response == "right")
                {
                    B2RoomA();
                }
                else if (response == "down")
                {
                    B2RoomD();
                }
                else
                {
                    validOption.Valid();
                    B2RoomB();
                }
            }
            else if (alreadyB2RoomB && readyToEscape && !tire4)
            {
                Console.WriteLine("\nYou found tire#4!\n" +
                    "Keep looking for the rest of the parts");
                tire4 = true;
                parts++;
                if (parts == 6)
                {
                    Finish();
                }
                else
                {
                    B2RoomB();
                }
            }
            else if (alreadyB2RoomB && readyToEscape && tire4)
            {
                Console.WriteLine("\nYou have already found the part in room B.\nGo right or down?");
                string response = Console.ReadLine().ToLower();
                if (response == "right")
                {
                    B2RoomA();
                }
                else if (response == "down")
                {
                    B2RoomD();
                }
                else
                {
                    validOption.Valid();
                    B2RoomB();
                }
            }
        }

        public void B2RoomC()
        {
            if (!alreadyB2RoomC && alreadyB2RoomB)
            {
                Console.WriteLine("\nYou found a gun!\nYou can go up or left");
                string response = Console.ReadLine().ToLower();
                user.hasGun = true;
                alreadyB2RoomC = true;
                if (response == "up")
                {
                    B2RoomA();
                }
                else if (response == "left")
                {
                    B2RoomD();
                }
                else
                {
                    validOption.Valid();
                    B2RoomC();
                }
            }
            else if (alreadyB2RoomB && alreadyB2RoomC && !readyToEscape)
            {
                Console.WriteLine("\nThis room is empty. \nYou can go left or up.");
                string response = Console.ReadLine();
                if (response == "left")
                {
                    B2RoomD();
                }
                else if (response == "up")
                {
                    B2RoomA();
                }
                else
                {
                    validOption.Valid();
                    B2RoomC();
                }
            }
            else if (alreadyB2RoomC && readyToEscape && !transmission)
            {
                Console.WriteLine("\nYou found a transmission!\n" +
                    "Keep looking for the rest of the parts");
                transmission = true;
                parts++;
                if (parts == 6)
                {
                    Finish();
                }
                else
                {
                    B2RoomC();
                }
            }
            else if (alreadyB2RoomC && readyToEscape && transmission)
            {
                Console.WriteLine("\nYou have already found the part in room C.\nGo up or left?");
                string response = Console.ReadLine().ToLower();
                if (response == "up")
                {
                    B2RoomA();
                }
                else if (response == "left")
                {
                    B2RoomD();
                }
                else
                {
                    validOption.Valid();
                    B2RoomC();
                }
            }
            else
            {
                Console.WriteLine("\nExplore more first");
                B2RoomA();
            }
        }

        public void B2RoomD()
        {
            if (!alreadyB2RoomD && !readyToEscape)
            {
                Console.WriteLine("\nYou have found an upgraded shield! \nYou can go up or right.");
                string response = Console.ReadLine().ToLower();
                alreadyB2RoomD = true;
                user.hasUS = true;
                if (response == "up")
                {
                    B2RoomB();
                }
                else if (response == "right")
                {
                    B2RoomC();
                }
                else
                {
                    validOption.Valid();
                    B2RoomD();
                }
            }
            else if (alreadyB2RoomD && !readyToEscape)
            {
                Console.WriteLine("\nThis room is empty. \nYou can go up or right.");
                string response = Console.ReadLine();
                if (response == "up")
                {
                    B2RoomB();
                }
                else if (response == "right")
                {
                    B2RoomC();
                }
                else
                {
                    validOption.Valid();
                    B2RoomD();
                }
            }
            else if (alreadyB2RoomD && readyToEscape && !engine)
            {
                Console.WriteLine("\nYou found the engine!\n" +
                    "Keep looking for the rest of the parts");
                engine = true;
                parts++;
                if (parts == 6)
                {
                    Finish();
                }
                else
                {
                    B2RoomD();
                }
            }
            else if (alreadyB2RoomD && readyToEscape && engine)
            {
                Console.WriteLine("\nYou have already found the part in room D.\nGo up or right?");
                string response = Console.ReadLine().ToLower();
                if (response == "up")
                {
                    B2RoomB();
                }
                else if (response == "right")
                {
                    B2RoomC();
                }
                else
                {
                    validOption.Valid();
                    B2RoomD();
                }
            }
        }

        public void B3()
        {
            if (user.hasGun && user.hasUS && !foughtMonster2)
            {
                monster2.FoundMonster();
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    Console.WriteLine("\nLet's Fight!!!");
                    while (user.isAlive && monster2.isAlive)
                    {
                        user.Attack(monster2);
                        monster2.Attack(user);
                    }
                    foughtMonster2 = true;
                    alreadyBuilding3 = true;
                    readyToEscape = true;
                    B3();
                }
                else if (response == "no")
                {
                    Console.WriteLine("\nYou chose not to fight and run like a scared child...");
                    B2RoomA();
                }
                else
                {
                    validOption.Valid();
                    B3();
                }
            }
            else if (alreadyBuilding3)
            {
                Console.WriteLine("\nYou have defeated this monster.\nGo outside? [yes or no]");
                string response = Console.ReadLine().ToLower();
                if (response == "yes")
                {
                    escape.Escape();
                    Console.WriteLine("\nWhich building would you like to check for parts first [1 or 2]?");
                    int partsChoice = Convert.ToInt32(Console.ReadLine());
                    if (partsChoice == 1)
                    {
                        RoomD();
                    }
                    else if (partsChoice == 2)
                    {
                        B2RoomA();
                    }
                    else
                    {
                        validOption.Valid();
                    }
                }             
                else if (response == "no")
                {
                    B3();
                }
                else
                {
                    validOption.Valid();
                    B3();
                }
            }
            else
            {
                Console.WriteLine("\nYou are not prepared to enter this building, please discover better equipment and then return...");
                B2RoomA();
            }
        }
    }
}
