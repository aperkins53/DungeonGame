using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonGameCopy.Character1;
using static DungeonGameCopy.GetawayVehicle;

namespace DungeonGameCopy
{
    public class Rooms
    {
        public string Name { get; set; }
        public int Building { get; set; }
        public Rooms Up { get; set; }
        public Rooms Down { get; set; }
        public Rooms Left { get; set; }
        public Rooms Right { get; set; }
        public Weapons Weapons { get; set; }
        public VehicleParts VehicleParts { get; set; }


        public void Room(string _name, int _blg, Rooms _up, Rooms _down, Rooms _right, Rooms _left, Weapons _weapon, VehicleParts _vehicle)
        {
            Name = _name;
            Building = _blg;
            Up = _up;
            Down = _down;
            Right = _right;
            Left = _left;
            Weapons = _weapon;
            VehicleParts = _vehicle;
        }

        public void GoToRoom(Rooms room)
        {
            Console.WriteLine($"You are in Building {room.Building} - {room.Name}.");
            Console.WriteLine("\nYou can go:");
            if (Up != null)
            {
                Console.WriteLine($"UP to room {Up}");
            }
            if (Down != null)
            {
                Console.WriteLine($"\nDOWN to room {Down}");
            }
            if (Right != null)
            {
                Console.WriteLine($"\nRIGHT to room {Right}");
            }
            if (Left != null)
            {
                Console.WriteLine($"\nLEFT to room {Left}");
            }
            string response = Console.ReadLine().ToLower();
            switch (response)
            {
                case ("up"):
                    room.GoToRoom(room.Up);
                    break;
                case ("down"):
                    room.GoToRoom(room.Down);
                    break;
                case ("right"):
                    room.GoToRoom(room.Right);
                    break;
                case ("left"):
                    room.GoToRoom(room.Left);
                    break;
            }
        }
    }
}
