using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DungeonGameCopy.Character1;
using static DungeonGameCopy.GetawayVehicle;

namespace DungeonGameCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            DungeonGame game = new DungeonGame();
            game.Run();

            Rooms B1RA = new Rooms() { };
            Rooms B1RB = new Rooms() { };
            Rooms B1RC = new Rooms() { };
            Rooms B1RD = new Rooms() { };
            Rooms B1RE = new Rooms() { };
            Rooms B2RA = new Rooms() { };
            Rooms B2RB = new Rooms() { };
            Rooms B2RC = new Rooms() { };
            Rooms B2RD = new Rooms() { };
            Rooms B3RA = new Rooms() { };
            B1RA.Room("Room A", 1, null, B1RD, B1RC, B1RB, Weapons.empty, VehicleParts.tire);
            B1RB.Room("Room B", 1, null, B1RE, B1RA, null, Weapons.sword, VehicleParts.empty);
            B1RC.Room("Room C", 1, null, null, null, B1RA, Weapons.shield, VehicleParts.tire);
            B1RD.Room("Room D", 1, B1RA, B2RA, null, B1RE, Weapons.empty, VehicleParts.tire);
            B1RE.Room("Room E", 1, B1RB, null, B1RD, null, Weapons.empty, VehicleParts.empty);
            B2RA.Room("Room A", 2, null, B2RC, B3RA, B2RB, Weapons.empty, VehicleParts.tire);
            B2RB.Room("Room B", 2, null, B2RD, B2RA, null, Weapons.ammo, VehicleParts.empty);
            B2RC.Room("Room C", 2, B2RA, null, null, B2RC, Weapons.gun, VehicleParts.engine);
            B2RD.Room("Room D", 2, B2RB, null, B2RC, null, Weapons.ammo, VehicleParts.transmission);
            B3RA.Room("Room A", 3, B2RA, null, null, null, Weapons.empty, VehicleParts.empty);
        }
    }
}
