using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonGameCopy;

namespace DungeonGameCopy
{
    public class GetawayVehicle
    {
        public bool readyToEscape = false;
        public bool tire1 = false;
        public bool tire2 = false;
        public bool tire3 = false;
        public bool tire4 = false;
        public bool engine = false;
        public bool transmission = false;
        public int parts = 0;
        public enum VehicleParts { empty, tire, engine, transmission }
        public bool winning = false;

        public void Escape()
        {
            Console.WriteLine("\nYou have found a vehicle! But it is missing several parts.\n" +
                "Go back through the buildings to find the needed parts and escape this dump");
        }     
        
        public void Finish()
        {
            winning = true;
            Console.WriteLine("Congrats, you have found all the parts!!!!\n" +
                "You fixed the car and escaped the dungeon!!!!");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
