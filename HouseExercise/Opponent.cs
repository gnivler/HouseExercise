using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExercise
{
    class Opponent
    {
        private Location myLocation;
        private Random random;

        public Opponent(Location location)
        {
            myLocation = location;
            random = new Random();
        }

        public void Move()
        {
            if (myLocation is IHasExteriorDoor)
            {
                if (random.Next(2) == 1)        // coin flip to go through the door or not
                {
                    {
                        IHasExteriorDoor door = myLocation as IHasExteriorDoor;
                        myLocation = door.DoorLocation;
                    }
                }
                // choose a location from available exits and keep moving until there is a hiding space
                myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                while (myLocation is IHidingPlace == false)
                    myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
            }
        }

        public bool Check(Location location)
        {
            if (location == myLocation)
                return true;
            return false;
        }
    }
}
