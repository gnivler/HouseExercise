using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                int num = random.Next(2);
                if (num == 1)        // coin flip to go through the door or not
                {
                    // downcast myLocation to an interface reference to get at the DoorLocation property
                    IHasExteriorDoor door = myLocation as IHasExteriorDoor;
                    myLocation = door.DoorLocation;
                }
            }
            // choose a location from available exits and keep moving until there is a hiding space
            //myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
            do
            {
                int num = random.Next((myLocation.Exits.Length));
                myLocation = myLocation.Exits[num];
            }
            while (myLocation is IHidingPlace == false);
        }

        public bool Check(Location location)
        {
            if (location == myLocation)
                return true;
            return false;
        }
    }
}
